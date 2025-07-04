using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("����������δ��ʵ��");
                return null;
            }
            return instance;
        }
    }

    public Dictionary<string, SceneBase> dictScene;

    /// <summary>
    /// ����һ������
    /// </summary>
    /// <param name="name">Ŀ�곡������</param>
    /// <param name="sceneBace">Ŀ�곡��scene</param>
    public void LoadScene(string name, SceneBase sceneBace)
    {
        if(!dictScene.ContainsKey(name))
            dictScene.Add(name, sceneBace);
        if (dictScene.ContainsKey(SceneManager.GetActiveScene().name))
            dictScene[SceneManager.GetActiveScene().name].ExitScene();
        else Debug.LogError($"SceneControlδ��¼{SceneManager.GetActiveScene().name}!");

        #region pop()
        GameRoot.Instance.UIManagerRoot.Clear();
        #endregion
        SceneManager.sceneLoaded += sceneBace.EnterScene;
        SceneManager.LoadScene(name);
    }

    public SceneController()
    {
        instance = this;
        dictScene = new Dictionary<string, SceneBase>();
    }
}
