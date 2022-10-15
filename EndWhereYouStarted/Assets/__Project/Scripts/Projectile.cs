
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 3;
    public float DamageAmount = 1;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * Speed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<IDamageable>()?.GetHit(DamageAmount);
        Destroy(gameObject);
    }
}
