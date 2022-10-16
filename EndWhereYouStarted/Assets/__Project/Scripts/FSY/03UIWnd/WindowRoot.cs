/*************************************************
	����: UI���ڻ���
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
    /// ���ô�����ʾ״̬
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
    /// ��ʼ������֮��
    /// </summary>
    protected virtual void InitWnd()
    {
        //���㲻��Ҫ��.Instance
        root = GameRoot.Instance;
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
    }
    /// <summary>
    /// �رմ���֮��Ĳ���
    /// </summary>
    protected virtual void UnInitWnd()
    {
        root = null;
        resSvc = null;
        audioSvc = null;
    }
    //����
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
    //����Text�������
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
    //����ͼƬ
    protected void SetSprite(Image image, string path)
    {
        Sprite sp = ResSvc.Instance.LoadSprite(path, true);
        image.sprite = sp;
    }
    /// <summary>
    /// ��ȡTransform�����������trans�����忪ʼ��
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
    /// �õ�Image�������
    /// </summary>
    /// <param name="trans">�����Transform���󣬴����￪ʼ��</param>
    /// <param name="path">·��</param>
    /// <returns></returns>
    protected Image GetImage(Transform trans, string path)
    {
        if (trans != null)
        {
            return trans.Find(path).GetComponent<Image>();
        }
        else//�������Transform���������忪ʼ�� 
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
    /// ��ȡ/���ĳ������������return �����������岻���ڸ������������һ��
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
    /// ���OnClick�¼�
    /// </summary>
    /// <param name="go">���������</param>
    /// <param name="clickCB">����ص�</param>
    /// <param name="args">����¼�����</param>
    protected void OnClick(GameObject go, Action<PointerEventData, object[]> clickCB, params object[] args)
    {
        //��ȡ�����PEListener���
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onClick = clickCB;
        if (args != null) //���û����������һ��
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