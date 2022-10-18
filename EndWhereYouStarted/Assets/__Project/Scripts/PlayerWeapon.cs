
using UnityEngine;

public class PlayerWeapon
{
    private static readonly float FireInterval = 3.1f;
    private static readonly float ExchangeInterval = 0.5f;
    private static readonly float TossSpeed = 3f;

    private float _firedTime = -10;
    private float _exchangedTime;

    private GameObject _capture;

    public void FixedUpdate()
    {
        Fire();
        Exchange();
    }

    private void Fire()
    {
        if (!(InputManager.HoldingFire && _firedTime + FireInterval < Time.time)) return;

        _firedTime = Time.time;
        _exchangedTime = Time.time;

        Vector2 a = Player.Instance.FirePoint.position;
        Vector2 b = InputManager.MousePos;
        float distance = (b - a).magnitude;
        Vector2 direction = (b - a).normalized;
        float intensity = Mathf.Lerp(0, 3, distance);

        GameObject bombGameObject = GameObject.Instantiate(Player.Instance.ProjectilePrefab, Player.Instance.FirePoint.position, Quaternion.identity);
        _capture = bombGameObject;
        bombGameObject.GetComponent<Rigidbody2D>().velocity = direction * intensity * TossSpeed;
        bombGameObject.GetComponent<Bomb>().ExplosionEvent += Explosion;
    }

    private void Explosion(GameObject bombGameObject)
    {
        if (bombGameObject != _capture) return;
        bombGameObject.GetComponent<Bomb>().ExplosionEvent -= Explosion;
        _capture = null;
    }

    private void Exchange()
    {
        if (_capture == null || !InputManager._holdingExchange || _exchangedTime + ExchangeInterval > Time.time) return;

        _exchangedTime = Time.time;

        Transform playerTransform = Player.Instance.transform;
        (playerTransform.position, _capture.transform.position) = (_capture.transform.position, playerTransform.position);
    }

    public void Disappear()
    {
        if(_capture != null) _capture.GetComponent<Bomb>().Disappear();
    }
}
