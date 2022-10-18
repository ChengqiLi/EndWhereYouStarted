
using UnityEngine;

public class PlayerTempSave
{
    private TempSavePoint _capture;

    public void Capture(TempSavePoint newCapture)
    {
        if (_capture == newCapture) return;
        if(_capture != null) _capture.LoseFocus();
        _capture = newCapture;
        _capture.GainFocus();
    }

    public void FixedUpdate()
    {
        if (InputManager._holdingReplay && _capture != null)
        {
            Player.Instance._weapon.Disappear();
            Player.Instance.transform.position = _capture.transform.position;

            var timers = GameObject.FindGameObjectsWithTag("TimerMechanism");
            for (int i = 0; i < timers.Length; i++)
            {
                timers[i].GetComponent<TimerMechanism>().Close();
            }
        }
    }
}
