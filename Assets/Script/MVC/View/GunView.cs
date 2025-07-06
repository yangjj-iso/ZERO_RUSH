using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunView : MonoBehaviour
{
    TextMeshProUGUI _overloadRate, _shotMode;
    GameObject _muzzle;
    public GameObject Muzzle { get =>  _muzzle; }
    // Start is called before the first frame update
    void Start()
    {
        _overloadRate = transform.Find("OverloadRate").GetComponent<TextMeshProUGUI>();
        _shotMode = transform.Find("ShotMode").GetComponent<TextMeshProUGUI>();
        _muzzle = transform.Find("GunBody").Find("Muzzle").gameObject;
    }

    public void UpdateView(GunModel gunModel)
    {
        _overloadRate.text = $"过载进度: {gunModel.OverloadRate.ToString("#0.00")}/{gunModel.Gun.MaxOverloadRate.ToString("#0.00")}";
        switch(gunModel.Gun.ShotMode)
        {
            case GunBase.ShotModeType.SingleShot:
                _shotMode.text = "单发";break;
            case GunBase.ShotModeType.TripleShot:
                _shotMode.text = "三连发";break;
            case GunBase.ShotModeType.Automatic:
                _shotMode.text = "全自动";break;
        }
    }
}
