/*************************************************
	功能: 音频服务
*************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AudioSvc : MonoBehaviour {
    public static AudioSvc Instance;
    //开关，默认开
    public bool TurnOnVoice;
    public AudioSource bgAudio;
    public AudioSource uiAudio;

    public void InitSvc() {
        Instance = this;
        Debug.Log("Init AudioSvc Done");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.F1)) {
            TurnOnVoice = true;
        }
        else if(Input.GetKeyDown(KeyCode.F2)) {
            TurnOnVoice = false;
        }
    }
    /// <summary>
    /// 关闭背景音乐
    /// </summary>
    public void StopBGMusic() {
        if(bgAudio != null) {
            bgAudio.Stop();
        }
    }
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    /// <param name="isLoop"></param>
    public void PlayBGMusic(string name, bool isLoop = true) {
        if(!TurnOnVoice) {
            return;
        }
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if(bgAudio.clip == null || bgAudio.clip.name != audio.name) {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }
    /// <summary>
    /// 播放UI音效
    /// </summary>
    /// <param name="name"></param>
    public void PlayUIAudio(string name) {
        if(!TurnOnVoice) {
            return;
        }
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        uiAudio.clip = audio;
        uiAudio.Play();
    }

    public void PlayEntityAudio(string name, AudioSource audioSrc, bool loop = false, int delay = 0) {
        if(!TurnOnVoice) {
            return;
        }

        void PlayAudio() {
            AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
            audioSrc.clip = audio;
            audioSrc.loop = loop;
            audioSrc.Play();
        }

        if(delay == 0) {
            PlayAudio();
        }
        else {
            StartCoroutine(DelayPlayAudio(delay * 1.0f / 1000, PlayAudio));
        }
    }

    IEnumerator DelayPlayAudio(float sec, Action cb) {
        yield return new WaitForSeconds(sec);
        Debug.Log("yield play audio:" + name);
        cb?.Invoke();
    }
}
