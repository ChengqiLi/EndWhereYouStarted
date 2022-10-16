using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWnd : WindowRoot
{
    public Button buttonJiXu;
    public Button buttonAgain;
    public Button buttonQuit;
    public Button menuButton;
    public GameObject menu;
    void Start()
    {
        buttonJiXu.onClick.AddListener(ButtonClickJiXu);
    }
    
    public void ButtonClickJiXu()
    {
        Debug.Log("ButtonClickJiXu()");
        SetWndState(false);
        Time.timeScale = 1;
    }

    void Update()
    {

    }
}
