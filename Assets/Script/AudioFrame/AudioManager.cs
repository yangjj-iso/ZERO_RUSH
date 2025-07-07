using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioManager 
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {  
        get 
        { 
            if (_instance == null)
            {
                Debug.LogError("音频控制器未绑定实例");
                return null;
            }
            return _instance;
        }
    }
    private AudioSource _audioSource;
    private Dictionary<string, AudioClip> _audioClipDict;
    /// <summary>
    /// 加载新音效
    /// </summary>
    /// <param name="audio"></param>
    public void Add(AudioType audio)
    {
        if(_audioClipDict.ContainsKey(audio.Name))
        {
            Debug.LogError($"已加载{audio.Name}音效");
            return;
        }
        AudioClip audioClip = Resources.Load<AudioClip>(audio.Path);
        _audioClipDict.Add(audio.Name, audioClip);
    }

    /// <summary>
    /// 播放音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayAudio(string name)
    {
        if (!_audioClipDict.ContainsKey(name))
        {
            Debug.LogError($"字典中没有{name}音效");
            return;
        }
        _audioSource.clip = (_audioClipDict[name]);
        _audioSource.Play();
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name"></param>
    public void PlaySfx(string name)
    {
        if(!_audioClipDict.ContainsKey(name))
        {
            Debug.LogError($"字典中没有{name}音效");
            return;
        }
        _audioSource.PlayOneShot(_audioClipDict[name]);
    }

    public AudioManager(AudioSource audioSource)
    {
        _instance = this;
        _audioClipDict = new Dictionary<string, AudioClip>();
        _audioSource = audioSource;
        string jsonFilePath = Path.Combine(Application.dataPath, "Resources/Audio", "audio_list.json");
        AudioTypeList audioTypeList = SaveSystemTutorial.SaveSystem.LoadFromJson<AudioTypeList>(jsonFilePath);
        foreach (AudioType audioType in audioTypeList.audios)
        {
            Add(audioType);
        }
    }
}
