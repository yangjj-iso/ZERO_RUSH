using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GunBase
{
    [SerializeField]protected static GunType _gunType;
    public virtual GunType GunType {  get { return _gunType; } }
    [SerializeField] protected static float _basicFireRate = 0.1f;//��ʼ����
    public virtual float FireRate { get { return _basicFireRate; } }
    [SerializeField] protected static float _basicOverloadRate = 1.5f;//����������
    public virtual float OverloadRate
    {
        get { return _basicOverloadRate; }
    }
    [SerializeField] protected static float _basicCooldownRate = 5;//������ȴ�ٶ�
    public virtual float CooldownRate { get { return _basicCooldownRate; } }
    [SerializeField] protected static float _basicMaxOverloadRate = 100;//�������������ֵ
    public virtual float MaxOverloadRate { get { return _basicMaxOverloadRate; } }

    [SerializeField]protected BulletType _bulletType;
    public BulletType Bullet {  get { return _bulletType; } }

    [SerializeField] protected int _basicBulletNum = 1;//�������������ӵ���Ŀ
    public virtual int BulletNum
    {
        get { return _basicBulletNum; }
    }


    public enum ShotModeType
    {
        SingleShot,
        TripleShot,
        Automatic
    }
    [SerializeField] protected ShotModeType _shotMode;
    public ShotModeType ShotMode { get { return _shotMode; } }
    public abstract void SwitchShotMode();

    public GunBase()
    {
        _shotMode = ShotModeType.SingleShot;
    }
}
