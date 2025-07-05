using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRoot : MonoBehaviour
{
    private static AudioSource _audioSource;
    private static AudioRoot _instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogWarning("音频管理器没有绑定实例！");
                return null;
            }
            return _instance;
        }
    }

    private AudioManager _audioManager;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioManager = new AudioManager(_audioSource);
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioManager.PlayAudio("Test");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
