using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeBullet : BulletBase
{
    private static readonly string bulletName = "PrototypeBullet";
    private static readonly string bulletPath = "Prefab/Weapon/Bullet/PrototypeBullet";
    private static new BulletType _bulletType = new BulletType(bulletName, bulletPath);
    public static new BulletType BulletType {  get { return _bulletType; } }
}
