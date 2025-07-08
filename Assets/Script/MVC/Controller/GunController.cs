using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private GunView _gunView;
    private GunModel _gunModel;
    
    //
    void Start()
    {
        _gunView = GetComponent<GunView>();
        if(_gunModel == null)_gunModel = new GunModel();
        _gunModel.OnUpdate += _gunView.UpdateView;
        _gunModel.OnShot += CreatBullet;
    }

    public void LoadGun(GunBase gun)
    {
        if (_gunModel == null)
        {
            _gunModel = new GunModel(gun);
        }
    }

    void Shot()
    {
        _gunModel.Shot();
    }

    void AutomaticShot()
    {
        _gunModel.AutomaticShot();
    }
    void CreatBullet(BulletType type)
    {
        AudioManager.Instance.PlaySfx("Shot");
        for (int i = 0; i < _gunModel.Gun.BulletNum; i++)
        {
            float rotation = Random.Range(-_gunModel.Gun.Dispersion * 5, _gunModel.Gun.Dispersion * 5);
            //Debug.Log(rotation);
            GameObject bullet = GameObject.Instantiate(BulletManager.Instance.Load(type.Name));
            bullet.transform.position = _gunView.Muzzle.transform.position;
            bullet.transform.right = Quaternion.AngleAxis(rotation, gameObject.transform.forward) * gameObject.transform.right;
            bullet.transform.SetParent(UIManager.Instance.CurrentPanel.activeObj.transform);
            bullet.GetComponent<BulletController>().SetInfo(_gunModel.Gun, new PrototypeBullet());
        }
    }
    void SwitchShotMode()
    {
        _gunModel.Gun.SwitchShotMode();
    }
    void Cooldown()
    {
        _gunModel.Cooldown(Time.deltaTime);
    }
    void Face2Mouse()
    {
        Vector2 display = transform.position;
        Vector2 mouse = Input.mousePosition;
        transform.right = mouse - display;
    }
    void TryFire()
    {
        _gunModel.Fire();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchShotMode();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
        if(Input.GetMouseButton(0))
        {
            AutomaticShot();
        }
        TryFire();
        Face2Mouse();
    }
}
