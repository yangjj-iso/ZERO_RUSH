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
                Debug.LogError("音频管理器未绑定实例");
                return null;
            }
            return _instance;
        }
    }
    private AudioSource _audioSource;
    private Dictionary<string, AudioClip> _audioClipDict;
    public void Add(AudioType audio)
    {
        if(_audioClipDict.ContainsKey(audio.Name))
        {
            Debug.LogError($"已加载同名音效{audio.Name}");
            return;
        }
        AudioClip audioClip = Resources.Load<AudioClip>(audio.Path);
        _audioClipDict.Add(audio.Name, audioClip);
    }

    public void PlayAudio(string name)
    {
        if (!_audioClipDict.ContainsKey(name))
        {
            Debug.LogError($"不存在名称为{name}的音效");
            return;
        }
        _audioSource.clip = (_audioClipDict[name]);
        _audioSource.Play();
    }

    public void PlaySfx(string name)
    {
        if(!_audioClipDict.ContainsKey(name))
        {
            Debug.LogError($"不存在名称为{name}的音效");
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
