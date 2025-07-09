using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    public UIType uiType;
    public bool activeFlag;

    /// <summary>
    /// 当前场景的GameObject
    /// </summary>
    public GameObject activeObj;

    public BasePanel(UIType uIType)
    {
        this.uiType = uIType;
    }

    /// <summary>
    /// UI第一次激活时触发
    /// </summary>
    public virtual void OnStart()
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = true;
        activeFlag = true;
    }

    /// <summary>
    /// UI被启用时触发
    /// </summary>
    public virtual void OnEnable() 
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = true;
        activeFlag = true;
    }

    /// <summary>
    /// UI被禁用时触发
    /// </summary>
    public virtual void OnDisable() 
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = false;
        activeFlag = false;
    }

    /// <summary>
    /// UI被摧毁时触发
    /// </summary>
    public virtual void OnDestroy()
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = false;
        activeFlag = false;
    }

    /// <summary>
    /// UI在更新序列中时触发
    /// </summary>
    public virtual void OnUpdate()
    {
        
    }
}
