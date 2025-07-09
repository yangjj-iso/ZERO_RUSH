using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunType
{
    [SerializeField]string _name, _path;
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
}
