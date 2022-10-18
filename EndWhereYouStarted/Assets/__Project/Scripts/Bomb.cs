
using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Duration = 3;
    public float DamageAmount = 1;

    [NonSerialized] public Rigidbody2D _rb;
    public GameObject ExplosionPrefab;

    public event Action<GameObject> ExplosionEvent;
    private bool _disappear;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, Duration);
    }

    private void OnDestroy()
    {
        if (!_disappear) Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        ExplosionEvent?.Invoke(gameObject);
    }

    public void Disappear()
    {
        _disappear = true;
        Destroy(gameObject);
    }
}
