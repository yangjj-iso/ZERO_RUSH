using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BulletManager
{
    private static BulletManager _instance;
    public static BulletManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("子弹管理器未绑定实例!");
            }
            return _instance;
        }
    }
    private static readonly string _jsonFilePath = Path.Combine(Application.dataPath, "Resources/Prefab/Weapon", "bullet_list.json");
    private static Dictionary<string, GameObject> _bulletDict;
    /// <summary>
    /// 通过BulletType读取子弹实体
    /// </summary>
    /// <param name="type"></param>
    public void Add(BulletType type)
    {
        if (_bulletDict.ContainsKey(type.Name))
        {
            Debug.LogError($"名称为{type.Name}的子弹已加载过");
            return;
        }
        GameObject gameObject = Resources.Load<GameObject>(type.Path);
        if (gameObject != null) _bulletDict.Add(type.Name, Resources.Load<GameObject>(type.Path));
        else Debug.LogError($"未找到名称为{type.Name}，路径为{type.Path}的子弹");
    }

    /// <summary>
    /// 通过名称从内存中加载子弹实例
    /// </summary>
    /// <param name="name">子弹名称</param>
    /// <returns></returns>
    public GameObject Load(string name)
    {
        if(!_bulletDict.ContainsKey(name))
        {
            Debug.Log($"未加载名称为{name}的子弹实例");
            return null;
        }
        return _bulletDict[name];
    }

    public BulletManager()
    {
        _bulletDict = new Dictionary<string, GameObject>();
        if (_instance == null)_instance = this;
        BulletList bulletList = SaveSystemTutorial.SaveSystem.LoadFromJson<BulletList>( _jsonFilePath );
        if (bulletList != null)
        {
            foreach (var bullet in bulletList.bullets)
            {
                Add(bullet);
            }
        }
        else Debug.LogError("未找到子弹数据Json");
    }
}
