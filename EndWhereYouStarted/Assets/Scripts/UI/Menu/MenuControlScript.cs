using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControlScript : MonoBehaviour
{
    public Button buttonJiXu;
    public Button buttonAgain;
    public Button buttonQuit;
    public Button menuButton;
    public GameObject menu;
    void Start()
    {
        menu = transform.Find("Menu").gameObject;
        buttonJiXu = transform.Find("Menu/ButtonJiXu").GetComponent<Button>();
        buttonAgain = transform.Find("Menu/ButtonAgain").GetComponent<Button>();
        buttonQuit = transform.Find("Menu/ButtonQuit").GetComponent<Button>();
        menuButton = transform.Find("MenuButton").GetComponent<Button>();

        buttonJiXu.onClick.AddListener(ButtonClickJiXu);
        menuButton.onClick.AddListener(ButtonClickMenu);
    }
    public void ButtonClickMenu()//点击菜单按钮
    {
        menu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonClickJiXu()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
}
