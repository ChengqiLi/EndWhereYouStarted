
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public PropagateAnimation _propagateAnimation;

    private void Awake()
    {
        _propagateAnimation.AnimationFinishedEvent += AnimationFinished;
    }

    private void AnimationFinished()
    {
        Destroy(gameObject);
    }
}
