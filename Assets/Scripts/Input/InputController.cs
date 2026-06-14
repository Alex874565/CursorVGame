using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Vector2 MousePosition { get; private set; }
    
    public event Action<Vector2> OnMove;
    public event Action OnAttackPressed;
    public event Action OnAttackReleased;
    
    
    private InputSystem_Actions actions;
    
    private void Awake()
    {
        actions = new InputSystem_Actions();
    }

    private void Start()
    {
        SubscribeInput();
    }

    private void Update()
    {
        CheckMovement();
    }

    private void SubscribeInput()
    {
        actions.Player.Attack.performed += HandleAttackPressed;
        actions.Player.Attack.canceled += HandleAttackReleased;
    }

    private void HandleAttackPressed(InputAction.CallbackContext obj)
    {
        OnAttackPressed?.Invoke();
    }

    private void HandleAttackReleased(InputAction.CallbackContext obj)
    {
        OnAttackReleased?.Invoke();
    }

    private void CheckMovement()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 newMousePos = Camera.main.ScreenToWorldPoint(screenPos);
        if (Vector2.Distance(newMousePos, MousePosition) > 0.1f)
        {
            MousePosition = newMousePos;
            OnMove?.Invoke(MousePosition);
        }
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}