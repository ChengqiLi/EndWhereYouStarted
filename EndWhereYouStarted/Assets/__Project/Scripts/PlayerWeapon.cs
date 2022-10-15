
using UnityEngine;

public class PlayerWeapon
{
    private static readonly float FireInterval = 0.5f;

    private float _firedTime;

    public void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (!(InputManager.HoldingFire && _firedTime + FireInterval < Time.time)) return;

        _firedTime = Time.time;

        Vector2 mousePosition = InputManager.MousePos;
        Vector2 firePointPosition = Player.Instance.FirePoint.position;

        Vector3 vectorToTarget = mousePosition - firePointPosition;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
        GameObject.Instantiate(Player.Instance.ProjectilePrefab, firePointPosition, rotation);
    }
}
