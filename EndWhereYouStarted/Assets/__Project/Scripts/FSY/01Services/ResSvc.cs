/*************************************************   00
	功能: 资源服务
*************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour {
    public static ResSvc Instance;

    public void InitSvc() {
        Instance = this;
        Debug.Log("Init ResSvc Done.");
    }
    //进度检测
    private Action prgCB = null;
    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="loadRate">回调函数，告诉加载进度</param>
    /// <param name="loaded">加载完毕的回调函数</param>
    public void AsyncLoadScene(string sceneName, Action<float> loadRate, Action loaded) {
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);

        prgCB = () => {
            //获取加载进度
            float progress = sceneAsync.progress;
            loadRate?.Invoke(progress);
            if(progress == 1) //加载完毕
            {
                //回调加载完毕的函数
                loaded?.Invoke();
                prgCB = null;
                sceneAsync = null;
            }
        };
    }

    private void Update() 
    {
        //如果prgCB不是null，则每帧调用进度检测
        prgCB?.Invoke();
    }
    //字典缓存
    private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();
    /// <summary>
    /// 加载预设体
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cache"></param>
    /// <returns></returns>
    public GameObject LoadPrefab(string path, bool cache = false) {
        GameObject prefab = null;
        if(!goDic.TryGetValue(path, out prefab)) {
            prefab = Resources.Load<GameObject>(path);
            if(cache) {
                goDic.Add(path, prefab);
            }
        }

        GameObject go = null;
        if(prefab != null) {
            go = Instantiate(prefab);
        }
        return go;
    }
    //字典缓存
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
    /// <summary>
    /// 加载音效
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cache"></param>
    /// <returns></returns>
    public AudioClip LoadAudio(string path, bool cache = false) {
        AudioClip au = null;
        if(!adDic.TryGetValue(path, out au)) {//如果缓存中没有该键值对
            au = Resources.Load<AudioClip>(path);
            if(cache)//如果 cache为true则缓存
            {
                adDic.Add(path, au);
            }
        }
        return au;
    }

    private Dictionary<string, Sprite> spDic = new Dictionary<string, Sprite>();
    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cache"></param>
    /// <returns></returns>
    public Sprite LoadSprite(string path, bool cache = false) {
        Sprite sp = null;
        if(!spDic.TryGetValue(path, out sp)) {
            sp = Resources.Load<Sprite>(path);
            if(cache) {
                spDic.Add(path, sp);
            }
        }
        return sp;
    }

    
}
