using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    BulletView _bulletView;
    BulletModel _bulletModel;
    // Start is called before the first frame update
    void Awake()
    {
        _bulletView = GetComponent<BulletView>();
        _bulletModel = new BulletModel();
        _bulletModel.OnDestory += DestoryBullet;
    }

    public void SetInfo(GunBase gun, BulletBase bullet)
    {
        _bulletModel.SetInfo(gun, bullet);
    }
    
    private void Move()
    {
        if(_bulletModel.Bullet == null) return;
        transform.position += _bulletModel.Bullet.Speed * transform.right;
    }
    private void DestoryBullet()
    {
        GameObject.Destroy(gameObject);
    }
    private void DecreaseTime()
    {
        _bulletModel.DecreaseTime(Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DecreaseTime();
    }
}
