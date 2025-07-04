using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneBase
{
    /// <summary>
    /// 进入该场景时触发
    /// </summary>
    public virtual void EnterScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.sceneLoaded -= EnterScene;
    }
    /// <summary>
    /// 退出该场景时触发
    /// </summary>
    public abstract void ExitScene();

}
