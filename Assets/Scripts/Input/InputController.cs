using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputSystem_Actions actions;

    public Vector2 MousePosition { get; private set; }

    private void Awake()
    {
        actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        MousePosition = Camera.main.ScreenToWorldPoint(screenPos);
    }
}