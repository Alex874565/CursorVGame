using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementComponent))]
public class Player : MonoBehaviour
{
    private PlayerInputController _playerInputController;
    private MovementComponent _movementComponent;
    private WeaponController _weaponController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _movementComponent = GetComponent<MovementComponent>();
        
        List<object> movementSubjects = new List<object>{_playerInputController};
        _movementComponent.Subscribe(movementSubjects);
        
        List<object> weaponSubjects = new List<object>{_playerInputController};
        _weaponController = GetComponentInChildren<WeaponController>();
        _weaponController.Initialize(weaponSubjects);
    }
}