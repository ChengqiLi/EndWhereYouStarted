using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : WindowRoot
{
    public Button menuButton;
    public Button audioBtton;
    public MenuWnd menuWnd;
    public SettingWnd settingWnd;
    private void Awake()
    {
        menuButton.onClick.AddListener(() =>
        {
            menuWnd.SetWndState(true);
        });

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
