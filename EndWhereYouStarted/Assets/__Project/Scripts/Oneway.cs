
using UnityEngine;

public class Oneway : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        float p = Mathf.Max(0, Vector2.Dot(transform.right, rb.velocity));
        float q = Vector2.Dot(transform.up, rb.velocity);
        rb.velocity = (p + 1) * transform.right + q * transform.up;
    }
}
