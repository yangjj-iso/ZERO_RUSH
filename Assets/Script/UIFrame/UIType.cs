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
    /// ��ȡUI�����Ϣ
    /// </summary>
    /// <param name="UIName">UI����</param>
    /// <param name="UIPath">UI·��</param>
    public UIType(string UIName, string UIPath)
    {
        this.name = UIName;
        this.path = UIPath;
    }
}
