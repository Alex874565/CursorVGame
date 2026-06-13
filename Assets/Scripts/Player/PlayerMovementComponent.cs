using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MovementComponent
{
    private Rigidbody2D _rb;

    private bool _shouldMove = true;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void Move()
    {
        if (!_shouldMove) return;

        if (Vector2.Distance(moveTarget, _rb.position) > 0.05f)
        {
            _rb.MovePosition(moveTarget);
        }
    }

    private void Update()
    {
        Move();
    }
}