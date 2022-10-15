
using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance => _instance;

    [NonSerialized] public Camera _camera;

    private void Awake()
    {
        _instance = this;

        _camera = GetComponent<Camera>();
    }
}
