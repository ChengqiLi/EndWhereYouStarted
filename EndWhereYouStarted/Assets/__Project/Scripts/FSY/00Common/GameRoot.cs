/*************************************************

	功能: 客户端入口

*************************************************/

using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {
    public static GameRoot Instance;
    public Transform uiRoot;
    public SettingWnd settingWnd;
    public StartWnd startWnd;
    public MenuWnd menuWnd;

    void Awake() {
        Instance = this;
        InitRoot();
        Init();

        
    }
    public void Start()
    {
        audioSvc.PlayBGMusic("battle");
        audioSvc.PlayUIAudio("battle");

        startWnd.SetWndState(true);

    }
    void Update() {
       
    }

    void InitRoot() {
        //for(int i = 0; i < uiRoot.childCount; i++)//取消激活Canvas所有的子物体
        //{
        //    Transform trans = uiRoot.GetChild(i);
        //    trans.gameObject.SetActive(false);
        //}

    }

    private ResSvc resSvc;
    private AudioSvc audioSvc;

    void Init() {

        //初始化服务

        resSvc = GetComponent<ResSvc>();
        resSvc.InitSvc();
        audioSvc = GetComponent<AudioSvc>();
        audioSvc.InitSvc();

        
    }


    
}
