using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingWnd : WindowRoot
{
    public static SettingWnd Instance;
    public Slider bgSlider;
    public Slider uiSlider;
    public AudioSource bgAudio;
    public AudioSource uiAudio;
    public GameObject root;

    public Button closeBtn;
    void Start()
    {
        bgAudio.volume = 0.3f;
        bgSlider.value = bgAudio.volume;


        uiAudio.volume = 0.3f;
        uiSlider.value =uiAudio.volume;
        // ����¼���ÿ�λ������������һ��
        bgSlider.onValueChanged.AddListener(ChangeBGVolume);
        uiSlider.onValueChanged.AddListener(ChangeUIVolume);


    }
    public void Awake()
    {
  
        if (Instance != this&&Instance!=null)
        {
            //���ⱻ�л�����ʱ�����µ������Instanceˢ��
        }
        if(Instance==null)
        {
            Instance = this;
        }



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
