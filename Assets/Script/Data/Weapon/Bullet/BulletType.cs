using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class BulletType
{
    [SerializeField] string _name, _path;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Path
    {
        get { return _path; }
        set { _path = value; }
    }

    public BulletType(string name, string path)
    {
        _name = name;
        _path = path;
    }
}
