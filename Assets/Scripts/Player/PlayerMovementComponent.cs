using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MovementComponent
{
    private Rigidbody2D _rb;
    private InputController _inputController;

    private bool _shouldMove = true;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void Subscribe(List<object> subjects)
    {
        foreach (var subject in subjects)
        {
            if (subject is InputController inputController)
            {
                _inputController = inputController;
                _inputController.OnMove += HandleMovement;
                break;
            }
        }
    }

    private void OnDestroy()
    {
        if (_inputController != null)
            _inputController.OnMove -= HandleMovement;
    }
    
    protected override void Move()
    {
        if (!_shouldMove) return;

        if (Vector2.Distance(moveTarget, _rb.position) > 0.05f)
        {
            _rb.MovePosition(moveTarget);
        }
    }

    private void HandleMovement(Vector2 target)
    {
        if (_shouldMove)
        {
            moveTarget = target;
        }
    }
    
    private void FixedUpdate()
    {
        Move();
    }
}