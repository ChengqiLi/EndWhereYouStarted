
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _instance = this;

        _playerInput = GetComponent<PlayerInput>();

        _playerInput.actions.FindAction("MousePosition").performed += MousePosition;
        _playerInput.actions.FindAction("Move").performed += PerformDirInput;
        _playerInput.actions.FindAction("Move").canceled += ReleaseDirInput;
        _playerInput.actions.FindAction("Jump").performed += PerformJump;
        _playerInput.actions.FindAction("Jump").canceled += CancelJump;
        _playerInput.actions.FindAction("Fire").performed += PerformFire;
        _playerInput.actions.FindAction("Fire").canceled += CancelFire;
        _playerInput.actions.FindAction("Exchange").performed += PerformExchange;
        _playerInput.actions.FindAction("Exchange").canceled += CancelExchange;
        _playerInput.actions.FindAction("Replay").performed += PerformReplay;
        _playerInput.actions.FindAction("Replay").canceled += CancelReplay;
        _playerInput.actions.FindAction("Item1").performed += LogName;
        _playerInput.actions.FindAction("Item2").performed += LogName;
        _playerInput.actions.FindAction("Item3").performed += LogName;
        _playerInput.actions.FindAction("Item4").performed += LogName;
        _playerInput.actions.FindAction("Item5").performed += LogName;
        _playerInput.actions.FindAction("Item6").performed += LogName;
        _playerInput.actions.FindAction("Item7").performed += LogName;
        _playerInput.actions.FindAction("Item8").performed += LogName;
        _playerInput.actions.FindAction("Item9").performed += LogName;
        _playerInput.actions.FindAction("Escape").performed += QuitApplication;
    }

    public void LogName(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.name);
    }

    private static bool _holdingMove;
    public static bool HoldingMove => _holdingMove;

    private static Vector2 _dirInput;
    public static Vector2 DirInput => _dirInput;

    private static int _xInput;
    public static int XInput => _xInput;

    private static Vector2 _screenPos;

    private void PerformDirInput(InputAction.CallbackContext context)
    {
        _holdingMove = true;
        _dirInput = context.ReadValue<Vector2>();
        _xInput = (int)Mathf.Sign(_dirInput.x);
    }

    private void ReleaseDirInput(InputAction.CallbackContext context)
    {
        _holdingMove = false;
        _dirInput = Vector2.zero;
        _xInput = 0;
    }

    public static bool _holdingJump;
    private void PerformJump(InputAction.CallbackContext context) => _holdingJump = true;
    private void CancelJump(InputAction.CallbackContext context) => _holdingJump = false;

    private static bool _holdingFire;
    public static bool HoldingFire => _holdingFire;
    public static Vector2 MousePos => CameraManager.Instance._camera.ScreenToWorldPoint(_screenPos);

    private void PerformFire(InputAction.CallbackContext context) => _holdingFire = true;
    private void CancelFire(InputAction.CallbackContext context) => _holdingFire = false;

    private void MousePosition(InputAction.CallbackContext context) => _screenPos = context.ReadValue<Vector2>();

    public static bool _holdingExchange;
    private void PerformExchange(InputAction.CallbackContext context) => _holdingExchange = true;
    private void CancelExchange(InputAction.CallbackContext context) => _holdingExchange = false;

    public static bool _holdingReplay;
    private void PerformReplay(InputAction.CallbackContext context) => _holdingReplay = true;
    private void CancelReplay(InputAction.CallbackContext context) => _holdingReplay = false;

    private void QuitApplication(InputAction.CallbackContext context)
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
