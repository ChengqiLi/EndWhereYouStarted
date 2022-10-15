
using System;
using UnityEngine;

public class PropagateAnimation : MonoBehaviour
{
    public event Action AnimationFinishedEvent;

    public void AnimationFinished()
    {
        AnimationFinishedEvent?.Invoke();
    }
}
