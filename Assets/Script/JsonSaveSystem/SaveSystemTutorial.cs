using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveSystemTutorial
{
    public static class SaveSystem
    {
        #region JSON
        /// <summary>
        /// 序列化类到Application.persistentDataPath/saveFilePath
        /// </summary>
        /// <param name="saveFilePath"></param>
        /// <param name="data"></param>
        public static void SaveByJson(string saveFilePath, object data)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(Application.persistentDataPath, saveFilePath);
            FileInfo fileInfo = new FileInfo(path);
            Debug.Log(fileInfo.Directory.FullName);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
                #if UNITY_EDITOR
                Debug.Log("已创建{saveFilePath}");
                #endif
            }
            try
            {
                File.WriteAllText(path, json);
                #if UNITY_EDITOR
                Debug.Log($"已保存到{path}");
                #endif
            }
            catch(System.Exception e)
            {
                Debug.LogError($"保存到{path}时发生错误\n错误原因：{e}");
            }
        }

        /// <summary>
        /// 从Json中反序列化数据
        /// </summary>
        /// <typeparam name="T">目标数据类型</typeparam>
        /// <param name="saveFilePath"></param>
        /// <returns></returns>
        public static T LoadFromJson<T>(string saveFilePath)
        {
            string path = Path.Combine(Application.persistentDataPath , saveFilePath);
            try
            {
                string json = File.ReadAllText(path);
                T data = JsonUtility.FromJson<T>(json);
                return data;
            }
            catch (System.Exception e)
            {
                #if UNITY_EDITOR
                Debug.LogError($"从{path}中读取数据时发生错误\n错误原因：{e}");
                #endif
                throw e;
            }
        }
        #endregion

        #region Deleteing

        /// <summary>
        /// 从Application.persistentDataPath中删除文件
        /// </summary>
        /// <param name="saveFilePath"></param>
        public static void DeleteFile(string saveFilePath)
        {
            string path = Path.Combine(Application.persistentDataPath, saveFilePath);
            try
            {
                File.Delete(path);
                #if UNITY_EDITOR
                Debug.Log($"已删除{path}");
                #endif
            }
            catch (System.Exception e)
            {
                #if UNITY_EDITOR
                Debug.LogError($"从{path}中删除数据时发生错误，错误原因：{e}");
                #endif
            }
        }
        #endregion
    }

}
