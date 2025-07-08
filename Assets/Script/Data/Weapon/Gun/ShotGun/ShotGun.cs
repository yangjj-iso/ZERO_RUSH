using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static GunBase;

/* 
 * 描述：霰弹枪
 * 作者：sine5RAD
 */
public class ShotGun : GunBase
{
    public override void SwitchShotMode()
    {
        switch (ShotMode)
        {
            case GunBase.ShotModeType.SingleShot:
                _shotMode = ShotModeType.SingleShot; break;
            default:
                throw new System.Exception($"不存在的射击模式");
        }
    }
    public ShotGun()
    {
        _bulletType = PrototypeBullet.BulletType;
        _basicBulletNum = 10;
        _basicFireRate = 5;
        _basicDispersion = 1;
    }
}
