
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public PropagateAnimation _propagateAnimation;
    private CircleCollider2D _collider;
    private Collider2D[] _resultsCache;

    private void Awake()
    {
        _propagateAnimation.AnimationFinishedEvent += AnimationFinished;
        _collider = GetComponent<CircleCollider2D>();
        _resultsCache = new Collider2D[20];
        ApplyDamage();
    }

    private void AnimationFinished()
    {
        Destroy(gameObject);
    }

    private void ApplyDamage()
    {
        int n = _collider.OverlapCollider(new ContactFilter2D(){useTriggers = true}, _resultsCache);
        for (int i = 0; i < n; i++)
        {
            IDamageable damageable = _resultsCache[i].GetComponent<IDamageable>();
            damageable?.GetHit(1);
        }
    }
}
