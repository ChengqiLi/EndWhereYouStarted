/**********************************************************************
挂载：
功能说明：

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
    //点击（点击-按下-抬起）事件回调
    public Action<PointerEventData, object[]> onClick;
    //按下事件回调
    public Action<PointerEventData, object[]> onClickDown;
    //抬起事件回调
    public Action<PointerEventData, object[]> onClickUp;
    //拖拽事件回调
    public Action<PointerEventData, object[]> onDrag;
    //可变参数
    public object[] args = null;
    /// <summary>
    /// 实现IPointerClickHandler接口，点击事件
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(eventData, args);
    }
    /// <summary>
    /// 实现IPointerDownHandler接口，按下事件
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