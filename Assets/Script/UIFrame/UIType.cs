using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private string name;
    public string Name
    {
        get => name;
    }

    private string path;
    public string Path
    {
        get => path;
    }

    /// <summary>
    /// 获取UI类的信息
    /// </summary>
    /// <param name="UIName">UI名称</param>
    /// <param name="UIPath">UI路径</param>
    public UIType(string UIName, string UIPath)
    {
        this.name = UIName;
        this.path = UIPath;
    }
}
