using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//挂给跳跃按钮
public class JumpButton : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button = GameObject.Find("ButtonJump").GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);
    }
    public void ButtonClick()
    {
        if (PlayerScript.Instance.isGround)
        {
            PlayerScript.Instance.canJump = true;
        }
        PlayerScript.Instance.Jump();
    }
}
