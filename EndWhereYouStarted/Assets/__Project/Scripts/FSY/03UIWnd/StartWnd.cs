using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartWnd : WindowRoot
{
    public Button buttonStart;
    public Button buttonHelp;
    public Button buttonExit;

    private void Awake()
    {

        
        buttonStart.onClick.AddListener(() =>
        {
            SetWndState(false);
        });
        OnClickDown(buttonStart.gameObject, (evt, args) =>
        {
           
            SetWndState(false);
        });

        OnClickDown(buttonHelp.gameObject, (evt, args) =>
        {
            ConfirmWnd.AddMsg("游戏玩法如下：。。。", null, null);
        });
        OnClickDown(buttonExit.gameObject, (evt, args) =>
        {

            Application.Quit();
        });
    }
    /// <summary>
    /// 打开窗口之后
    /// </summary>
    protected  override void InitWnd()
    {
        base.InitWnd();
        //暂停
        Time.timeScale = 0;
    }

    /// <summary>
    /// 关闭窗口之后
    /// </summary>
    protected override void UnInitWnd()
    {
        base.UnInitWnd();
        //开始
        Time.timeScale = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
