using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFieldScene : SceneBase
{
    public override void EnterScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        base.EnterScene(scene, loadSceneMode);
        UIManager.Instance.Push(new BattleFieldPanel(BattleFieldPanel.uiType));
    }

    public override void ExitScene()
    {
    }
}
