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
    /// 获取全局画布
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject == null)
        {
            Debug.LogError("未找到全局Canvas");
            return null;
        }
        return gameObject;
    }

    /// <summary>
    /// 在UI面板中通过名字寻找子物体
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject FindObjectInChildren(GameObject panel, string name)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();
        foreach(var transform in  transforms)
        {
            if (transform.gameObject.name == name) return transform.gameObject;
        }
        Debug.LogError($"UI{panel.name}的子物体中不包含名为{name}的物体");
        return null;
    }

    /// <summary>
    /// 获取UI面板的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public T GetComponent<T>(GameObject gameObject) where T : Component
    {
        if(gameObject.GetComponent<T>()!=null)
        {
            return (T)gameObject.GetComponent<T>();
        }
        Debug.LogError($"{gameObject.name}不包含{typeof(T)}组件");
        return default(T);
    }

    /// <summary>
    /// 通过名字获取UI面板子物体中的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public T GetComponentInChildren<T>(GameObject gameObject, string name) where T : Component
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach(var transform in transforms)
        {
            if(transform.gameObject.name == name)
                return transform.gameObject.GetComponent<T>();
        }
        Debug.LogError($"名为{gameObject.name}不包含{typeof(T)}组件");
        return default(T);
    }

    /// <summary>
    /// 为UI面板添加组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    public void AddComponent<T>(GameObject gameObject) where T : Component
    {
        gameObject.AddComponent<T>();
    }

    /// <summary>
    /// 通过名字为UI面板子物体添加组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <param name="name"></param>
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
        Debug.LogError($"{gameObject.name}的子物体中不包含名为{name}的物体");
    }
}
