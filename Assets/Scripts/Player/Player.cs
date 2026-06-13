using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementComponent))]
public class Player : MonoBehaviour
{
    private InputController _inputController;
    private PlayerMovementComponent _movementComponent;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        _movementComponent = GetComponent<PlayerMovementComponent>();
    }

    private void Update()
    {
        _movementComponent.SetMoveTarget(_inputController.MousePosition);
    }
}