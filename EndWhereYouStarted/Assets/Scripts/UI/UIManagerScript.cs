using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance;//单例
    public GameObject HealthBar;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);//防止切换场景保留
        HealthBar = GameObject.Find("HealthBar");
    }
    public void UpdateHealth(float currentHealth)
    {
        switch(currentHealth)
        {
            case 3:
                HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                HealthBar.transform.GetChild(1).gameObject.SetActive(true);
                HealthBar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                HealthBar.transform.GetChild(1).gameObject.SetActive(true);
                HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                HealthBar.transform.GetChild(1).gameObject.SetActive(false);
                HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            default:
                HealthBar.transform.GetChild(0).gameObject.SetActive(false);
                HealthBar.transform.GetChild(1).gameObject.SetActive(false);
                HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
        }
    }
}
