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
                Debug.LogWarning("GameRoot没实现!");
                return _instance;
            }
            return _instance;
        }
    }
    public UIManager UIManagerRoot { get => UIManager.Instance; }
    public SceneController SceneControlRoot { get => SceneController.Instance; }
    public GunManager GunManagerRoot { get => GunManager.Instance; }
    public BulletManager BulletManagerRoot { get => BulletManager.Instance; }
    

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
        SceneController.Instance.dictScene.Add("MainMenuScene", new MainMenuScene());
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        UIManager.canvasObj = UIMethods.Instance.FindCanvas();

        #region 开始游戏
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
