using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MovementComponent
{
    private Rigidbody2D _rb;
    private PlayerInputController _playerInputController;

    private bool _shouldMove = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void Subscribe(List<object> subjects)
    {
        foreach (var subject in subjects)
        {
            if (subject is PlayerInputController inputController)
            {
                _playerInputController = inputController;
                _playerInputController.OnMoveCursor += HandleMovement;
                _playerInputController.OnLeftClickPressed += HandleAttackStarted;
                _playerInputController.OnLeftClickReleased += HandleAttackEnded;
                break;
            }

        }
    }

    private void OnDestroy()
    {
        if (_playerInputController != null)
        {
            _playerInputController.OnMoveCursor -= HandleMovement;
            _playerInputController.OnLeftClickPressed -= HandleAttackStarted;
            _playerInputController.OnLeftClickReleased -= HandleAttackEnded;
        }
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

    private void HandleAttackStarted()
    {
        _shouldMove = false;
    }

    private void HandleAttackEnded()
    {
        _shouldMove = true;
    }

private void FixedUpdate()
    {
        Move();
    }
}