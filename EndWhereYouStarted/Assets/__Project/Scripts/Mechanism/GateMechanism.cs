
using UnityEngine;

public class GateMechanism : MonoBehaviour
{
    private BoxCollider2D _collider;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void Open()
    {
        _collider.enabled = false;
        _sr.enabled = false;
    }

    public void Close()
    {
        _collider.enabled = true;
        _sr.enabled = true;
    }
}
