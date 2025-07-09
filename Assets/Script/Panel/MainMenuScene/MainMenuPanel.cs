using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    private static string _name = "MainMenuPanel";
    private static string _path = "Prefab/Panel/MainMenuScene/MainMenuPanel";
    public static readonly UIType uIType = new UIType(_name, _path);
    public MainMenuPanel(UIType uIType) : base(uIType)
    {
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethods.Instance.GetComponentInChildren<Button>(activeObj, "OpenBattleFieldScene").onClick.AddListener(OpenBattleFieldScene);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public void OpenBattleFieldScene()
    {
        SceneController.Instance.LoadScene("BattleFieldScene", new BattleFieldScene());
    }
}
