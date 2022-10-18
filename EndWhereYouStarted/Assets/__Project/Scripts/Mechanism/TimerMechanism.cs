
using TMPro;
using UnityEngine;

public class TimerMechanism : MonoBehaviour, IDamageable
{
    public float Countdown = 5;
    public GameObject[] _linkedGameObjects;
    public TMP_Text _text;

    private bool _open;
    private float _startTime;

    public void GetHit(float damage)
    {
        _startTime = Time.time;
        if (!_open) Open();
    }

    private void FixedUpdate()
    {
        if (!_open) return;

        if (_startTime + Countdown < Time.time)
        {
            Close();
            return;
        }

        _text.text = $"{GetCooldown()}";
    }

    private int GetCooldown()
    {
        return (int)(_startTime + Countdown - Time.time) + 1;
    }

    private void Open()
    {
        _open = true;
        _text.text = $"{GetCooldown()}";
        foreach (GameObject link in _linkedGameObjects)
        {
            GateMechanism gate = link.GetComponent<GateMechanism>();
            if (gate == null) return;

            gate.Open();
        }
    }

    public void Close()
    {
        _open = false;
        _text.text = "X";
        foreach (GameObject link in _linkedGameObjects)
        {
            GateMechanism gate = link.GetComponent<GateMechanism>();
            if (gate == null) return;

            gate.Close();
        }
    }
}
