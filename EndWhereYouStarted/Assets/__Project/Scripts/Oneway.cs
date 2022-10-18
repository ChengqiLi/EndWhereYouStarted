
using UnityEngine;

public class Oneway : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        if (collider.GetComponent<Player>() != null) return;

        float x = Mathf.Max(0.1f, Vector2.Dot(transform.right, rb.velocity));
        float y = Vector2.Dot(transform.up, rb.velocity);
        rb.velocity = x * transform.right + y * transform.up;
    }
}
