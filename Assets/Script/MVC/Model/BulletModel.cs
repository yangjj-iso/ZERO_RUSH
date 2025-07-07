using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletModel
{
    private GunBase _gun;
    public GunBase Gun {  get { return _gun; } }
    BulletBase _bullet;
    public BulletBase Bullet { get { return _bullet; } }
    private float _remainingTime;
    public float RemainingTime {  get { return _remainingTime; } set { _remainingTime = value; } }

    public event UnityAction<BulletModel> OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke(this);
    }

    /// <summary>
    /// 保存发射该子弹枪的类型
    /// </summary>
    /// <param name="gun"></param>
    /// <param name="bullet"></param>
    public void SetInfo(GunBase gun, BulletBase bullet)
    {
        _gun = gun;
        _bullet = bullet;
        _remainingTime = bullet.MaxExistTime;
    }

    /// <summary>
    /// 每帧减少相应的存在时间
    /// </summary>
    /// <param name="deltaTime"></param>
    public void DecreaseTime(float deltaTime)
    {
        _remainingTime -= deltaTime;
        if (_remainingTime <= 0) OnDestory?.Invoke();

    }
    public event UnityAction OnDestory;
}
