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
                Debug.LogError("�ӵ�������δ��ʵ��!");
            }
            return _instance;
        }
    }
    private static readonly string _jsonFilePath = Path.Combine(Application.dataPath, "Resources/Prefab/Weapon", "bullet_list.json");
    private static Dictionary<string, GameObject> _bulletDict;
    /// <summary>
    /// ͨ��BulletType��ȡ�ӵ�ʵ��
    /// </summary>
    /// <param name="type"></param>
    public void Add(BulletType type)
    {
        if (_bulletDict.ContainsKey(type.Name))
        {
            Debug.LogError($"����Ϊ{type.Name}���ӵ��Ѽ��ع�");
            return;
        }
        GameObject gameObject = Resources.Load<GameObject>(type.Path);
        if (gameObject != null) _bulletDict.Add(type.Name, Resources.Load<GameObject>(type.Path));
        else Debug.LogError($"δ�ҵ�����Ϊ{type.Name}��·��Ϊ{type.Path}���ӵ�");
    }

    /// <summary>
    /// ͨ�����ƴ��ڴ��м����ӵ�ʵ��
    /// </summary>
    /// <param name="name">�ӵ�����</param>
    /// <returns></returns>
    public GameObject Load(string name)
    {
        if(!_bulletDict.ContainsKey(name))
        {
            Debug.Log($"δ��������Ϊ{name}���ӵ�ʵ��");
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
        else Debug.LogError("δ�ҵ��ӵ�����Json");
    }
}
