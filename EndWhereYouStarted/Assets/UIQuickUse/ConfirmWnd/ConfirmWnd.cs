//功能：ConfirmTipWindow，确认弹窗
//挂载：挂载给ConfirmTipWindow预设体
//1.打开关闭原理：
//通过隐藏ConfirmTipWindowt下面的BGImage图片（以及它的子物）来达到隐藏弹窗的目的
//2.显示队列：
//要显示的消息加入队列，然后等队首的显示完关闭了才能显示下一个
//3.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWnd : MonoBehaviour
{

    
    
    //是否正在展示
    private bool isShowing;
    //消息队列
    private static Queue<Msg> msgQueue = new Queue<Msg>();
    //消息
    class Msg
    {
        //消息
        public string msg;
        //确认回调
        public Action confirmAction;
        //取消回调
        public Action cancelAction;
        //构造函数
        public Msg(string msg, Action confirmAction, Action cancelAction)
        {
            this.msg = msg;
            this.confirmAction = confirmAction;
            this.cancelAction = cancelAction;
        }
    }

    //单例
    public static ConfirmWnd Instance;
    
    public GameObject bgImage;
    public Button confirmButton;
    //确认回调
    public Action confirmAction=null;
    public Button cancelButton=null;
    //取消回调
    public Action cancelAction;
    public Text text;
    public void Awake()
    {
        if (Instance != this && Instance != null)
        {
            //避免被切换场景时产生新的物体把Instance刷掉
        }
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        bgImage = transform.Find("BGImage").gameObject;
        confirmButton = transform.Find("BGImage/WndImage/ConfirmButton").GetComponent<Button>();
        cancelButton = transform.Find("BGImage/WndImage/CancelButton").GetComponent<Button>();
        text= transform.Find("BGImage/WndImage/Scroll View/Viewport/Content/Text").GetComponent<Text>();
        

        confirmButton.onClick.AddListener(OnConfirmButton);
        cancelButton.onClick.AddListener(OnCancelButton);
        //隐藏
        bgImage.SetActive(false);
    }
    /// <summary>
    /// 往队列添加要显示的消息
    /// </summary>
    /// <param name="msg">要显示的文字信息</param>
    /// <param name="confirmAction">按下确认后的回调</param>
    /// <param name="cancelAction">按下取消后的回调</param>
    public static void AddMsg(string msg,Action confirmAction=null,Action cancelAction=null)
    {
        lock (msgQueue)
        {
            msgQueue.Enqueue(new Msg(msg,confirmAction, cancelAction));

        }
    }
    void Update()
    {
        if (msgQueue.Count > 0 && isShowing == false)
        {
            lock (msgQueue)
            {
                Msg msg = msgQueue.Dequeue();
                isShowing = true;
                ShowWnd(msg.msg);
                this.confirmAction = msg.confirmAction;
                this.cancelAction = msg.cancelAction;
            }
        }
    }
    //显示窗口
    private void ShowWnd(string msg)
    {

        text.text = msg;
        bgImage.SetActive(true);
    }
    //按下确认按钮
    public void OnConfirmButton()
    {
        //AudioSvc.Instance.PlayUIAudio("ButtonComClick");
        //确认回调
        if (confirmAction!=null)
        {
            confirmAction();
        }

        CloseWnd();
    }
    //按下取消按钮
    public void OnCancelButton()
    {
        //AudioSvc.Instance.PlayUIAudio("ButtonComClick");
        if (cancelAction!=null)
        {
            cancelAction();
        }
        CloseWnd();
    }
    public void CloseWnd()
    {
        bgImage.SetActive(false);
        isShowing = false;
    }
}
