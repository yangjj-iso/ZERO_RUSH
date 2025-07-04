using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : SceneBase
{
    public override void EnterScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        base.EnterScene(scene, loadSceneMode);
        UIManager.Instance.Push(new MainMenuPanel(MainMenuPanel.uIType));
    }

    public override void ExitScene()
    {
    }
}
