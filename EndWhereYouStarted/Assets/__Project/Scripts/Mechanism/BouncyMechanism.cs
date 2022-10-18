
using UnityEngine;

public class BouncyMechanism : MonoBehaviour
{
    public float SpeedGain;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        rb.velocity += (Vector2)transform.up * SpeedGain;
    }
}
