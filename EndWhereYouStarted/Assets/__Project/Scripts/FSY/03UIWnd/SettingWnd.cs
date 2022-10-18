using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingWnd : WindowRoot
{
    public Slider bgSlider;
    public Slider uiSlider;
    public AudioSource bgAudio;
    public AudioSource uiAudio;
    public GameObject root;

    public Button closeBtn;
    void Awake()
    {
        bgAudio.volume = 0.3f;
        bgSlider.value = bgAudio.volume;


        uiAudio.volume = 0.3f;
        uiSlider.value =uiAudio.volume;
        // 添加事件，每次滑动，都会调用一次
        bgSlider.onValueChanged.AddListener(ChangeBGVolume);
        uiSlider.onValueChanged.AddListener(ChangeUIVolume);

        closeBtn.onClick.AddListener(() =>
        {
            SetWndState(false);
        });
    }
    
   
    private void ChangeBGVolume(float value)//参数value就是在滑动之后当前滑动条的滑块值,等于_slider.value
    {
        bgAudio.volume = value;
    }

    private void ChangeUIVolume(float value)//参数value就是在滑动之后当前滑动条的滑块值,等于_slider.value
    {
        uiAudio.volume = value;
    }
}
