using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 MousePosition { get; private set; }

    public event Action<Vector2> OnMoveCursor;
    public event Action OnLeftClickPressed;
    public event Action OnLeftClickReleased;

    private InputSystem_Actions actions;
    private Camera mainCamera;
    private Vector2 _attackStartMousePosition;

    private void Awake()
    {
        actions = new InputSystem_Actions();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        actions.Player.Attack.performed += HandleLeftClickPressed;
        actions.Player.Attack.canceled += HandleLeftClickReleased;

        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Player.Attack.performed -= HandleLeftClickPressed;
        actions.Player.Attack.canceled -= HandleLeftClickReleased;

        actions.Disable();
    }

    private void Update()
    {
        CheckMovement();
    }

    private void HandleLeftClickPressed(InputAction.CallbackContext ctx)
    {
        OnLeftClickPressed?.Invoke();
    }

    private void HandleLeftClickReleased(InputAction.CallbackContext ctx)
    {
        TeleportCursorToWorldPoint(gameObject.transform.position);
        OnLeftClickReleased?.Invoke();
    }

    private void CheckMovement()
    {
        if (Mouse.current == null || mainCamera == null)
            return;

        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 newMousePos = mainCamera.ScreenToWorldPoint(screenPos);

        if (Vector2.Distance(newMousePos, MousePosition) > 0.1f)
        {
            MousePosition = newMousePos;
            OnMoveCursor?.Invoke(MousePosition);
        }
    }
    
    public void TeleportCursorToWorldPoint(Vector2 worldPoint)
    {
        if (Mouse.current == null || mainCamera == null)
            return;

        Vector2 screenPoint = mainCamera.WorldToScreenPoint(worldPoint);

        Mouse.current.WarpCursorPosition(screenPoint);
        MousePosition = worldPoint;

        OnMoveCursor?.Invoke(MousePosition);
    }
}