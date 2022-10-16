
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float InitialSpeed = 3;
    public float DamageAmount = 1;

    private Rigidbody2D _rb;
    public GameObject ExplosionPrefab;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * InitialSpeed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<IDamageable>()?.GetHit(DamageAmount);
        if (ExplosionPrefab != null) Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
