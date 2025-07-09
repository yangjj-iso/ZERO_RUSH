using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)_instance = new UIManager();
            return _instance;
        }
    }
    public Dictionary<string, GameObject> dictUIObject;
    public Stack<BasePanel> stackUI;

    /// <summary>
    /// 当前场景下的画布（canvas）.
    /// </summary>
    public static GameObject canvasObj;
    public BasePanel CurrentPanel { get => stackUI.Peek(); }
    private UIManager() 
    {
        _instance = this;
        stackUI = new Stack<BasePanel>();
        dictUIObject = new Dictionary<string, GameObject>();
    }
    
    /// <summary>
    /// 获取UIType对应的界面
    /// </summary>
    /// <param name="uiType">画布类型</param>
    /// <returns></returns>
    public GameObject GetSingleObject(UIType uiType) 
    {
        if (dictUIObject.ContainsKey(uiType.Name))
            return dictUIObject[uiType.Name];
        //如果该UI已经加载到内存中（即在字典里），直接返回
        if(canvasObj == null)
        {
            Debug.LogError("未找到画布");
            return null;
        }
        //如果当前场景下没有画布，说明出了问题
        //Debug.Log("RUA!");
        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.Path));
        dictUIObject.Add(uiType.Name, gameObject);
        //将新UI加载到内存中（添加到字典中）
        return gameObject;
    }

    /// <summary>
    /// 向UI堆栈中推入一个UI，此UI显示在最顶层
    /// </summary>
    /// <param name="ui">新UI</param>
    public void Push(BasePanel ui) 
    {
        if (stackUI.Count > 0)
        {
            stackUI.Peek().OnDisable();
        }
        GameObject basePanelObject = GetSingleObject(ui.uiType);
        //dictUIObject.Add(ui.uiType.Name, basePanelObject);
        //这里不需要Add，因为GetSingleObject保证加载的UI进入字典
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
        ui.OnStart();//推入栈顶后执行OnStart
        //防止双击什么的导致同一个UI弹出多次。如果栈顶的UI和加载的ui相同就忽略这次推入

    }

    /// <summary>
    /// 清空UI栈
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
    /// 弹出（关闭）栈顶UI
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
