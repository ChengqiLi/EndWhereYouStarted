
using System;
using UnityEngine;

public class TempSavePoint : MonoBehaviour
{
    public Color LoseFocusColor;
    public Color GainFocusColor;

    [NonSerialized] public SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void LoseFocus()
    {
        _sr.color = LoseFocusColor;
    }

    public void GainFocus()
    {
        _sr.color = GainFocusColor;
    }
}
