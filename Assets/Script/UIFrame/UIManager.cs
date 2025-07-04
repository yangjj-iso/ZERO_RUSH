using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public Dictionary<string, GameObject> dictUIObject;
    public Stack<BasePanel> stackUI;

    /// <summary>
    /// ��ǰ�����µĻ�����canvas��.
    /// </summary>
    public GameObject canvasObj;

    private static UIManager instance;
    public static UIManager Instance 
    {
        get
        {
            if (instance == null)
                throw new System.Exception("No such UIManager instance!");
            return instance;
        }
    }
    public BasePanel CurrentPanel { get => stackUI.Peek(); }
    public UIManager() 
    {
        instance = this;
        stackUI = new Stack<BasePanel>();
        dictUIObject = new Dictionary<string, GameObject>();
    }
    
    /// <summary>
    /// ��ȡUIType��Ӧ�Ľ���
    /// </summary>
    /// <param name="uiType">��������</param>
    /// <returns></returns>
    public GameObject GetSingleObject(UIType uiType) 
    {
        if (dictUIObject.ContainsKey(uiType.Name))
            return dictUIObject[uiType.Name];
        //�����UI�Ѿ����ص��ڴ��У������ֵ����ֱ�ӷ���
        if(canvasObj == null)
        {
            Debug.LogError("δ�ҵ�����");
            return null;
        }
        //�����ǰ������û�л�����˵����������
        //Debug.Log("RUA!");
        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.Path));
        dictUIObject.Add(uiType.Name, gameObject);
        //����UI���ص��ڴ��У���ӵ��ֵ��У�
        return gameObject;
    }

    /// <summary>
    /// ��UI��ջ������һ��UI����UI��ʾ�����
    /// </summary>
    /// <param name="ui">��UI</param>
    public void Push(BasePanel ui) 
    {
        if (stackUI.Count > 0)
        {
            stackUI.Peek().OnDisable();
        }
        GameObject basePanelObject = GetSingleObject(ui.uiType);
        //dictUIObject.Add(ui.uiType.Name, basePanelObject);
        //���ﲻ��ҪAdd����ΪGetSingleObject��֤���ص�UI�����ֵ�
        ui.activeObj = basePanelObject;

        if (stackUI.Count == 0)
        {
            stackUI.Push(ui);
        }
        else
        {
            if(stackUI.Peek().uiType.Name != ui.uiType.Name)
            {
                stackUI.Push(ui);
            }
        }
        ui.OnStart();//����ջ����ִ��OnStart
        //��ֹ˫��ʲô�ĵ���ͬһ��UI������Ρ����ջ����UI�ͼ��ص�ui��ͬ�ͺ����������

    }

    /// <summary>
    /// ���UIջ
    /// </summary>
    public void Clear()
    {
        while (stackUI.Count > 0)
        {
            stackUI.Peek().OnDisable();
            stackUI.Peek().OnDestroy();
            GameObject.Destroy(dictUIObject[stackUI.Peek().uiType.Name]);
            dictUIObject.Remove(stackUI.Peek().uiType.Name);
            stackUI.Pop();
        }
    }
    /// <summary>
    /// �������رգ�ջ��UI
    /// </summary>
    public void Pop()
    {
        stackUI.Peek().OnDisable();
        stackUI.Peek().OnDestroy();
        GameObject.Destroy(dictUIObject[stackUI.Peek().uiType.Name]);
        dictUIObject.Remove(stackUI.Peek().uiType.Name);
        stackUI.Pop();

        if (stackUI.Count > 0)
        {
            stackUI.Peek().OnEnable();
        }
    }
}
