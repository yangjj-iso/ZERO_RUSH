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
                Debug.LogError("��Ƶ������δ��ʵ��");
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
            Debug.LogError($"�Ѽ���ͬ����Ч{audio.Name}");
            return;
        }
        AudioClip audioClip = Resources.Load<AudioClip>(audio.Path);
        _audioClipDict.Add(audio.Name, audioClip);
    }

    public void PlayAudio(string name)
    {
        if (!_audioClipDict.ContainsKey(name))
        {
            Debug.LogError($"����������Ϊ{name}����Ч");
            return;
        }
        _audioSource.clip = (_audioClipDict[name]);
        _audioSource.Play();
    }

    public void PlaySfx(string name)
    {
        if(!_audioClipDict.ContainsKey(name))
        {
            Debug.LogError($"����������Ϊ{name}����Ч");
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
