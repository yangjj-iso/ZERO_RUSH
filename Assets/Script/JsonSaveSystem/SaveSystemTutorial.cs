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
        /// 将数据序列化为Json字符串，并保存到Application.persistentDataPath/saveFilePath
        /// </summary>
        /// <param name="saveFilePath">相对路径，记得带扩展名</param>
        /// <param name="data">需要序列化的数据</param>
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
                Debug.Log("成功创建文件夹{saveFilePath}");
                #endif
            }
            try
            {
                File.WriteAllText(path, json);
                #if UNITY_EDITOR
                Debug.Log($"成功保存到{path}");
                #endif
            }
            catch(System.Exception e)
            {
                Debug.LogError($"将数据保存到{path}时发生错误。\n错误原因：{e}");
            }
        }

        /// <summary>
        /// 从本地Json文件中加载数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="saveFilePath">Json文件路径，记得带扩展名</param>
        /// <returns>读取的数据</returns>
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
        //TODO: 这段代码我还没测试，所以到时候测试一下

        /// <summary>
        /// 删除Application.persistentDataPath中的目标文件
        /// </summary>
        /// <param name="saveFilePath">需要删除的文件路径，记得带扩展名</param>
        public static void DeleteFile(string saveFilePath)
        {
            string path = Path.Combine(Application.persistentDataPath, saveFilePath);
            try
            {
                File.Delete(path);
                #if UNITY_EDITOR
                Debug.Log($"成功删除{path}");
                #endif
            }
            catch (System.Exception e)
            {
                #if UNITY_EDITOR
                Debug.LogError($"{path}删除失败。\n错误原因：{e}");
                #endif
            }
        }
        #endregion
    }

}
