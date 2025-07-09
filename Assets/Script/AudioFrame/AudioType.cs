using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioType
{
    [SerializeField]private string _name, _path;
    public string Name
    {
        get { return _name; }
    }
    public string Path
    {
        get { return _path; } 
    }
    public AudioType(string name, string path)
    {
        _name = name;
        _path = path;
    }
}
