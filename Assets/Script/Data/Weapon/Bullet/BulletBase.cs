using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletBase
{
    [SerializeField] protected BulletType _bulletType;
    public BulletType BulletType { get { return _bulletType; } }

    [SerializeField] protected float _basicDamage = 50;
    public float Damage { get { return _basicDamage; } }//基础子弹伤害
    [SerializeField] protected float _basicSpeed = 1;
    public float Speed { get { return _basicSpeed; } }//基础子弹速度

    [SerializeField] protected float _basicMaxExistTime = 3;
    public float MaxExistTime {  get { return _basicMaxExistTime; } }//基础子弹最大存在时间
    public BulletBase()
    {

    }
}
