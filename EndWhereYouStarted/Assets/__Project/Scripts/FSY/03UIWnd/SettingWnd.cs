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
        // ����¼���ÿ�λ������������һ��
        bgSlider.onValueChanged.AddListener(ChangeBGVolume);
        uiSlider.onValueChanged.AddListener(ChangeUIVolume);

        closeBtn.onClick.AddListener(() =>
        {
            SetWndState(false);
        });
    }
    
   
    private void ChangeBGVolume(float value)//����value�����ڻ���֮��ǰ�������Ļ���ֵ,����_slider.value
    {
        bgAudio.volume = value;
    }

    private void ChangeUIVolume(float value)//����value�����ڻ���֮��ǰ�������Ļ���ֵ,����_slider.value
    {
        uiAudio.volume = value;
    }
}
