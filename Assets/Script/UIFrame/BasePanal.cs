using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    public UIType uiType;
    public bool activeFlag;

    /// <summary>
    /// UI��Unity�����ж�Ӧ��GameObject
    /// </summary>
    public GameObject activeObj;

    public BasePanel(UIType uIType)
    {
        this.uiType = uIType;
    }

    /// <summary>
    /// ��UI��ջʱ����
    /// </summary>
    public virtual void OnStart()
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = true;
        activeFlag = true;
    }

    /// <summary>
    /// ��UI������ʱ����
    /// </summary>
    public virtual void OnEnable() 
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = true;
        activeFlag = true;
    }

    /// <summary>
    /// ��UI���ر�ʱ����
    /// </summary>
    public virtual void OnDisable() 
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = false;
        activeFlag = false;
    }

    /// <summary>
    /// ��UI�����ڴ�������ʱ����
    /// </summary>
    public virtual void OnDestroy()
    {
        UIMethods.Instance.GetComponent<CanvasGroup>(activeObj).interactable = false;
        activeFlag = false;
    }

    /// <summary>
    /// ��UI������ջ�����߱��ʲô��Ҫˢ�µ�����µ���
    /// </summary>
    public virtual void OnUpdate()
    {
        
    }
}
