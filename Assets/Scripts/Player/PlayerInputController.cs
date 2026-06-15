using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 MousePosition { get; private set; }

    public event Action<Vector2> OnMove;
    public event Action OnAttackPressed;
    public event Action OnAttackReleased;

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
        actions.Player.Attack.performed += HandleAttackPressed;
        actions.Player.Attack.canceled += HandleAttackReleased;

        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Player.Attack.performed -= HandleAttackPressed;
        actions.Player.Attack.canceled -= HandleAttackReleased;

        actions.Disable();
    }

    private void Update()
    {
        CheckMovement();
    }

    private void HandleAttackPressed(InputAction.CallbackContext ctx)
    {
        OnAttackPressed?.Invoke();
    }

    private void HandleAttackReleased(InputAction.CallbackContext ctx)
    {
        TeleportCursorToWorldPoint(gameObject.transform.position);
        OnAttackReleased?.Invoke();
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
            OnMove?.Invoke(MousePosition);
        }
    }
    
    public void TeleportCursorToWorldPoint(Vector2 worldPoint)
    {
        if (Mouse.current == null || mainCamera == null)
            return;

        Vector2 screenPoint = mainCamera.WorldToScreenPoint(worldPoint);

        Mouse.current.WarpCursorPosition(screenPoint);
        MousePosition = worldPoint;

        OnMove?.Invoke(MousePosition);
    }
}