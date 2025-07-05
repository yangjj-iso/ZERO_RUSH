using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private static GameRoot _instance;
    public static GameRoot Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogWarning("GameRoot没有绑定实例!");
                return _instance;
            }
            return _instance;
        }
    }

    private UIManager _uiManager;
    public UIManager UIManagerRoot { get => _uiManager; }
    private SceneController _sceneController;
    public SceneController SceneControlRoot { get => _sceneController; }
    private GunManager _gunManager;
    public GunManager GunManager { get => _gunManager; }
    private BulletManager _bulletManager;
    public BulletManager BulletManager { get => _bulletManager; }
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _uiManager = new UIManager();
        _sceneController = new SceneController();
        _gunManager = new GunManager();
        _bulletManager = new BulletManager();
        SceneController.Instance.dictScene.Add("MainMenuScene", new MainMenuScene());
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _uiManager.canvasObj = UIMethods.Instance.FindCanvas();

        #region 推入开始游戏界面
        UIManager.Instance.Push(new MainMenuPanel(MainMenuPanel.uIType));
        #endregion
    }

    private void Update()
    {
        foreach(var i in UIManager.Instance.stackUI)
        {
            if(i.activeFlag)i.OnUpdate();
        }
    }
}
