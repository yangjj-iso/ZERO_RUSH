using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethods
{
    private static UIMethods instance;
    public static UIMethods Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UIMethods();
            }
            return instance;
        }
    }

    /// <summary>
    /// ��ȡ��ǰ�����Ļ���
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject == null)
        {
            Debug.LogError("�Ҳ�������");
            return null;
        }
        return gameObject;
    }

    public GameObject FindObjectInChildren(GameObject panel, string name)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();
        foreach(var transform in  transforms)
        {
            if (transform.gameObject.name == name) return transform.gameObject;
        }
        Debug.LogError($"Panel \"{panel.name}\" ������ \"{name}\"");
        return null;
    }

    public T GetComponent<T>(GameObject gameObject) where T : Component
    {
        if(gameObject.GetComponent<T>()!=null)
        {
            return (T)gameObject.GetComponent<T>();
        }
        Debug.LogError($"{gameObject.name} ������ {typeof(T)}");
        return default(T);
    }

    public T GetComponentInChildren<T>(GameObject gameObject, string name) where T : Component
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach(var transform in transforms)
        {
            if(transform.gameObject.name == name)
                return transform.gameObject.GetComponent<T>();
        }
        Debug.LogError($"{gameObject.name} ������ {typeof(T)}");
        return default(T);
    }

    public void AddComponent<T>(GameObject gameObject) where T : Component
    {
        gameObject.AddComponent<T>();
    }

    public void AddComponentInChildren<T>(GameObject gameObject, string name) where T :Component
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach(var transform in transforms)
        {
            if(transform.gameObject.name == name)
            {
                transform.gameObject.AddComponent<T>();
                return;
            }
        }
        Debug.LogError($"{gameObject.name} ������ {typeof(T)}");
    }
}
