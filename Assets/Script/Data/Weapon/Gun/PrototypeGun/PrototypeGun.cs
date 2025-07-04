using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeGun : GunBase
{
    public override void SwitchShotMode()
    {
        switch (ShotMode)
        {
            case GunBase.ShotModeType.SingleShot:
                _shotMode = ShotModeType.TripleShot; break;
            case GunBase.ShotModeType.TripleShot:
                _shotMode = ShotModeType.SingleShot; break;
            default:
                throw new System.Exception("�����ڵĿ���ģʽ");
        }
    }
    public PrototypeGun()
    {
        _bulletType = PrototypeBullet.BulletType;
    }
}
