using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D" + other.tag);
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("玩家受伤");
            other.GetComponent<IDamageable>().GetHit(1);
        }
        if(other.gameObject.CompareTag("Boom"))
        {
            Debug.Log("");
        }
    }
}
