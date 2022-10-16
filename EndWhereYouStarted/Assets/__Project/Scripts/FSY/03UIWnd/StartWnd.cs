using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartWnd : WindowRoot
{
    public Button buttonStart;
    public Button buttonHelp;
    public Button buttonExit;

    private void Awake()
    {

        
        buttonStart.onClick.AddListener(() =>
        {
            SetWndState(false);
        });
        OnClickDown(buttonStart.gameObject, (evt, args) =>
        {
           
            SetWndState(false);
        });

        OnClickDown(buttonHelp.gameObject, (evt, args) =>
        {
            ConfirmWnd.AddMsg("��Ϸ�淨���£�������", null, null);
        });
        OnClickDown(buttonExit.gameObject, (evt, args) =>
        {

            Application.Quit();
        });
    }
    /// <summary>
    /// �򿪴���֮��
    /// </summary>
    protected  override void InitWnd()
    {
        base.InitWnd();
        //��ͣ
        Time.timeScale = 0;
    }

    /// <summary>
    /// �رմ���֮��
    /// </summary>
    protected override void UnInitWnd()
    {
        base.UnInitWnd();
        //��ʼ
        Time.timeScale = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
