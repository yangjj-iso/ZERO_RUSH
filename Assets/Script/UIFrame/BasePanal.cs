using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    public UIType uiType;
    public bool activeFlag;

    /// <summary>
    /// UI在Unity引擎中对应的GameObject
    /// </summary>
    public GameObject activeObj;

    public BasePanel(UIType uIType)
    {
        this.uiType = uIType;
    }

    /// <summary>
    /// 在UI入栈时调用
    /// </summary>
    public virtual void OnStart()
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = true;
        activeFlag = true;
    }

    /// <summary>
    /// 在UI被启用时调用
    /// </summary>
    public virtual void OnEnable() 
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = true;
        activeFlag = true;
    }

    /// <summary>
    /// 在UI被关闭时调用
    /// </summary>
    public virtual void OnDisable() 
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = false;
        activeFlag = false;
    }

    /// <summary>
    /// 在UI被从内存中销毁时调用
    /// </summary>
    public virtual void OnDestroy()
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = false;
        activeFlag = false;
    }

    /// <summary>
    /// 当UI被置于栈顶或者别的什么需要刷新的情况下调用
    /// </summary>
    public virtual void OnUpdate()
    {
        
    }
}
