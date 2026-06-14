using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementComponent))]
public class Player : MonoBehaviour
{
    private InputController _inputController;
    private MovementComponent _movementComponent;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        _movementComponent = GetComponent<MovementComponent>();
        
        List<object> movementSubjects = new List<object>{_inputController};
        _movementComponent.Subscribe(movementSubjects);
    }
}