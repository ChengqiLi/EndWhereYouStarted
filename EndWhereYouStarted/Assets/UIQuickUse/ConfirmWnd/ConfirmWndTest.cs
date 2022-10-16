using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmWndTest : MonoBehaviour
{
    void Start()
    {
        //使用：
        /// <param name="msg">要显示的文字信息</param>
        /// <param name="confirmAction">按下确认后的回调</param>
        /// <param name="cancelAction">按下取消后的回调</param>
        ConfirmWnd.AddMsg("333", ()=> {
            Debug.Log("按下了确认");
        }, () => {
            Debug.Log("按下了取消");
        });

        ConfirmWnd.AddMsg("2221111111111111111111111111111111111111111111111111111111111111111111111111", null, null);
        ConfirmWnd.AddMsg("333", null, null);
        ConfirmWnd.AddMsg("333", null, null);
        ConfirmWnd.AddMsg("4444", null, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
