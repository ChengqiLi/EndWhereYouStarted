using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//攻击按钮
public class AttackButton : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button = GameObject.Find("ButtonAttack").GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);
    }
    public void ButtonClick()
    {
        PlayerScript.Instance.Attack();
    }
}
