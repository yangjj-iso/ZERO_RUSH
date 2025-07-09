using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldPanel : BasePanel
{
    private static readonly string name = "BattleFieldPanel";
    private static readonly string path = "Prefab/Panel/BattleFieldScene/BattleFieldPanel";
    public static readonly new UIType uiType = new UIType(name, path);
    GameObject _hand;

    public BattleFieldPanel(UIType uIType) : base(uIType)
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
        _hand = UIMethods.Instance.FindObjectInChildren(activeObj, "Hand");
        GameObject gun = GameObject.Instantiate(GunManager.Instance.Load("ShotGun"));
        gun.transform.SetParent(_hand.transform);
        gun.transform.position = _hand.transform.position;
        gun.GetComponent<GunController>().LoadGun(new ShotGun());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
