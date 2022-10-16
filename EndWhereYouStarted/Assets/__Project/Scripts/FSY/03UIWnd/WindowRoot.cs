/*************************************************
	功能: UI窗口基类
*************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour
{
    protected GameRoot root;
    protected ResSvc resSvc;
    protected AudioSvc audioSvc;
    /// <summary>
    /// 设置窗口显示状态
    /// </summary>
    /// <param name="isActive"></param>
    public virtual void SetWndState(bool isActive = true)
    {
        if (gameObject.activeSelf != isActive)
        {
            gameObject.SetActive(isActive);
        }
        if (isActive)
        {
            InitWnd();
        }
        else
        {
            UnInitWnd();
        }
    }
    /// <summary>
    /// 初始化窗口之后
    /// </summary>
    protected virtual void InitWnd()
    {
        //方便不需要用.Instance
        root = GameRoot.Instance;
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
    }
    /// <summary>
    /// 关闭窗口之后的操作
    /// </summary>
    protected virtual void UnInitWnd()
    {
        root = null;
        resSvc = null;
        audioSvc = null;
    }
    //激活
    protected void SetActive(GameObject go, bool state = true)
    {
        go.SetActive(state);
    }
    protected void SetActive(Transform trans, bool state = true)
    {
        trans.gameObject.SetActive(state);
    }
    protected void SetActive(RectTransform rectTrans, bool state = true)
    {
        rectTrans.gameObject.SetActive(state);
    }
    protected void SetActive(Image img, bool state = true)
    {
        img.gameObject.SetActive(state);
    }
    protected void SetActive(Text txt, bool state = true)
    {
        txt.gameObject.SetActive(state);
    }
    protected void SetActive(InputField ipt, bool state = true)
    {
        ipt.gameObject.SetActive(state);
    }
    //设置Text组件对象
    protected void SetText(Transform trans, int num = 0)
    {
        SetText(trans.GetComponent<Text>(), num.ToString());
    }
    protected void SetText(Transform trans, string context = "")
    {
        SetText(trans.GetComponent<Text>(), context);
    }
    protected void SetText(Text txt, int num = 0)
    {
        SetText(txt, num.ToString());
    }
    protected void SetText(Text txt, string context = "")
    {
        txt.text = context;
    }
    //设置图片
    protected void SetSprite(Image image, string path)
    {
        Sprite sp = ResSvc.Instance.LoadSprite(path, true);
        image.sprite = sp;
    }
    /// <summary>
    /// 获取Transform对象，如果不给trans则从面板开始找
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    protected Transform GetTrans(Transform trans, string name)
    {
        if (trans != null)
        {
            return trans.Find(name);
        }
        else
        {
            return transform.Find(name);
        }
    }
    /// <summary>
    /// 拿到Image组件对象
    /// </summary>
    /// <param name="trans">传入的Transform对象，从这里开始找</param>
    /// <param name="path">路径</param>
    /// <returns></returns>
    protected Image GetImage(Transform trans, string path)
    {
        if (trans != null)
        {
            return trans.Find(path).GetComponent<Image>();
        }
        else//如果不传Transform对象则从面板开始找 
        {
            return transform.Find(path).GetComponent<Image>();
        }
    }
    protected Image GetImage(Transform trans)
    {
        if (trans != null)
        {
            return trans.GetComponent<Image>();
        }
        else
        {
            return transform.GetComponent<Image>();
        }
    }
    protected Text GetText(Transform trans, string path)
    {
        if (trans != null)
        {
            return trans.Find(path).GetComponent<Text>();
        }
        else
        {
            return transform.Find(path).GetComponent<Text>();
        }
    }
    /// <summary>
    /// 获取/添加某个物体的组件并return 对象，若该物体不存在该组件则给它添加一个
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    private T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (t == null)
        {
            t = go.AddComponent<T>();
        }
        return t;
    }
    /// <summary>
    /// 添加OnClick事件
    /// </summary>
    /// <param name="go">点击的物体</param>
    /// <param name="clickCB">点击回调</param>
    /// <param name="args">点击事件传参</param>
    protected void OnClick(GameObject go, Action<PointerEventData, object[]> clickCB, params object[] args)
    {
        //获取物体的PEListener组件
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onClick = clickCB;
        if (args != null) //如果没有则给它添加一个
        {
            listener.args = args;
        }
    }
    protected void OnClickDown(GameObject go, Action<PointerEventData, object[]> clickDownCB, params object[] args)
    {
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onClickDown = clickDownCB;
        if (args != null)
        {
            listener.args = args;
        }
    }
    protected void OnClickUp(GameObject go, Action<PointerEventData, object[]> clickUpCB, params object[] args)
    {
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onClickUp = clickUpCB;
        if (args != null)
        {
            listener.args = args;
        }
    }
    protected void OnDrag(GameObject go, Action<PointerEventData, object[]> dragCB, params object[] args)
    {
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onDrag = dragCB;
        if (args != null)
        {
            listener.args = args;
        }
    }

}