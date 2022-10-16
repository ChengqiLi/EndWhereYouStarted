/**********************************************************************
���أ�
����˵����

***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PEListener :
    MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IDragHandler
{
    //��������-����-̧���¼��ص�
    public Action<PointerEventData, object[]> onClick;
    //�����¼��ص�
    public Action<PointerEventData, object[]> onClickDown;
    //̧���¼��ص�
    public Action<PointerEventData, object[]> onClickUp;
    //��ק�¼��ص�
    public Action<PointerEventData, object[]> onDrag;
    //�ɱ����
    public object[] args = null;
    /// <summary>
    /// ʵ��IPointerClickHandler�ӿڣ�����¼�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(eventData, args);
    }
    /// <summary>
    /// ʵ��IPointerDownHandler�ӿڣ������¼�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        onClickDown?.Invoke(eventData, args);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onClickUp?.Invoke(eventData, args);
    }
    public void OnDrag(PointerEventData eventData)
    {
        onDrag?.Invoke(eventData, args);
    }
}