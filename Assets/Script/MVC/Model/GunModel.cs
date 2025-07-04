using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunModel
{
    GunBase _gun;
    public GunBase Gun { get => _gun; }

    private float _overloadProgress;//过载进度
    public float OverloadRate 
    {
        get => _overloadProgress;
        private set
        {
            if (value < 0)
            {
                _overloadProgress = 0;
                _isOverloading = false;
            }
            else if (value > 100f)
            {
                _overloadProgress = 100;
                _isOverloading = true;
                _shotCount = 0;
            }
            else _overloadProgress = value;
        }
    }
    private bool _isOverloading;//正在过载
    public bool IsOverloading { get { return _isOverloading; } }
    private float _shotGap;
    public float ShotGap 
    { 
        get => _shotGap;
        private set
        {
            if(value < 0)_shotGap = 0;
            else _shotGap = value;
        }
    }

    public void LoadGun(GunBase gun)
    {
        _gun = gun;
        OnGunLoaded.Invoke(_gun); ;
    }
    public event UnityAction<GunBase> OnGunLoaded;

    public void Cooldown(float deltaTime)
    {
        OverloadRate -= deltaTime * Gun.CooldownRate;
        ShotGap -= deltaTime;
        Update();
    }
    private int _shotCount;//待发射子弹数目
    public int ShotCount { get => _shotCount; set => _shotCount = value; }

    private bool CanShot { get => ShotGap == 0 && !IsOverloading && ShotCount == 0; }
    public event UnityAction<BulletType> OnShot;
    public void Shot()
    {
        if (!CanShot) return;
        if (Gun.ShotMode == GunBase.ShotModeType.Automatic) return;
        switch(Gun.ShotMode)
        {
            case GunBase.ShotModeType.SingleShot:
                ShotCount += 1;break;
            case GunBase.ShotModeType.TripleShot:
                ShotCount += 3;break;
            case GunBase.ShotModeType.Automatic:
                ShotCount += 1;break;
        }
    }
    public void AutomaticShot()
    {
        if (!CanShot) return;
        if (Gun.ShotMode != GunBase.ShotModeType.Automatic) return;
        switch (Gun.ShotMode)
        {
            case GunBase.ShotModeType.SingleShot:
                ShotCount += 1; break;
            case GunBase.ShotModeType.TripleShot:
                ShotCount += 3; break;
            case GunBase.ShotModeType.Automatic:
                ShotCount += 1; break;
        }
    }

    public void Fire()
    {
        if (_shotGap > 0 || ShotCount <= 0) return;
        OnShot?.Invoke(Gun.Bullet);
        ShotCount -= 1;
        ShotGap += Gun.FireRate;
        OverloadRate += Gun.OverloadRate;
        Update();
    }

    public event UnityAction<GunModel> OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke(this);
    }

    public GunModel(GunBase gun)
    {
        _gun = gun;
        _overloadProgress = 0;
        _shotCount = 0;
        _shotGap = 0;
        _isOverloading = false;
    }
}
