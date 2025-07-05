using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneBase
{
    /// <summary>
    /// ����ó���ʱ����
    /// </summary>
    public virtual void EnterScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.sceneLoaded -= EnterScene;
    }
    /// <summary>
    /// �˳��ó���ʱ����
    /// </summary>
    public abstract void ExitScene();

}
