using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GunManager
{
    private static GunManager _instance;
    public static GunManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GunManager();
            }
            return _instance;
        }
    }
    private static readonly string _gunJsonPath = Path.Combine(Application.dataPath, "Resources/Prefab/Weapon", "gun_list.json");
    private Dictionary<string, GameObject> _gunDict;

    public void Add(GunType type)
    {
        if (_gunDict.ContainsKey(type.Name))
        {
            Debug.LogError($"名称为{type.Name}的枪械已加载过");
            return;
        }
        GameObject gameObject = Resources.Load<GameObject>(type.Path);
        if (gameObject != null) _gunDict.Add(type.Name, Resources.Load<GameObject>(type.Path));
        else Debug.LogError($"未找到名称为{type.Name}，路径为{type.Path}的枪械");
    }
    public GameObject Load(string name)
    {
        if (!_gunDict.ContainsKey(name))
        {
            Debug.Log($"未加载名称为{name}的武器实例");
            return null;
        }
        return _gunDict[name];
    }

    public GunManager()
    {
        _gunDict = new Dictionary<string, GameObject>();
        if (_instance == null) _instance = this;
        GunList gunList = SaveSystemTutorial.SaveSystem.LoadFromJson<GunList>(_gunJsonPath);
        if (gunList != null)
        {
            foreach (var gun in gunList.guns)
            {
                Add(gun);
            }
        }
        else Debug.LogError("未找到枪械数据Json");
    }
}
