using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Button menuButton;
    public Button audioBtton;
    public MenuWnd menuWnd;
    public SettingWnd settingWnd;
    private void Awake()
    {
        menuButton = transform.Find("MenuButton").GetComponent<Button>();
        menuButton.onClick.AddListener(() =>
        {
            menuWnd.SetWndState(true);
        });


        audioBtton = transform.Find("AudioBtton").GetComponent<Button>();
        audioBtton.onClick.AddListener(() =>
        {
            settingWnd.SetWndState(true);
        });
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
