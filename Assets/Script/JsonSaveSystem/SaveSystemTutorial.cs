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
        /// ���������л�ΪJson�ַ����������浽Application.persistentDataPath/saveFilePath
        /// </summary>
        /// <param name="saveFilePath">���·�����ǵô���չ��</param>
        /// <param name="data">��Ҫ���л�������</param>
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
                Debug.Log("�ɹ������ļ���{saveFilePath}");
                #endif
            }
            try
            {
                File.WriteAllText(path, json);
                #if UNITY_EDITOR
                Debug.Log($"�ɹ����浽{path}");
                #endif
            }
            catch(System.Exception e)
            {
                Debug.LogError($"�����ݱ��浽{path}ʱ��������\n����ԭ��{e}");
            }
        }

        /// <summary>
        /// �ӱ���Json�ļ��м�������
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="saveFilePath">Json�ļ�·�����ǵô���չ��</param>
        /// <returns>��ȡ������</returns>
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
                Debug.LogError($"��{path}�ж�ȡ����ʱ��������\n����ԭ��{e}");
                #endif
                throw e;
            }
        }
        #endregion

        #region Deleteing
        //TODO: ��δ����һ�û���ԣ����Ե�ʱ�����һ��

        /// <summary>
        /// ɾ��Application.persistentDataPath�е�Ŀ���ļ�
        /// </summary>
        /// <param name="saveFilePath">��Ҫɾ�����ļ�·�����ǵô���չ��</param>
        public static void DeleteFile(string saveFilePath)
        {
            string path = Path.Combine(Application.persistentDataPath, saveFilePath);
            try
            {
                File.Delete(path);
                #if UNITY_EDITOR
                Debug.Log($"�ɹ�ɾ��{path}");
                #endif
            }
            catch (System.Exception e)
            {
                #if UNITY_EDITOR
                Debug.LogError($"{path}ɾ��ʧ�ܡ�\n����ԭ��{e}");
                #endif
            }
        }
        #endregion
    }

}
