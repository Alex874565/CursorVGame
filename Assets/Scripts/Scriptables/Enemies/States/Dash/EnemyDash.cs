using UnityEngine;

public class EnemyDash : EnemyState
{
    [Header("Dash")]
    [SerializeField] protected float _range = 4f;
    [SerializeField] protected float _duration = 0.2f;

    protected Vector2 _target;
    protected Vector2 _direction;
    protected Rigidbody2D _rb;

    private Vector2 _startPosition;
    private float _dashTimer;

    public override void Enter()
    {
        base.Enter();

        _rb = _context.CollisionController.Rb;
        _startPosition = _rb.position;
        _dashTimer = 0f;
    }

    protected void StartDash()
    {
        float distance = Vector2.Distance(_startPosition, _target);
        float dashSpeed = distance / _duration;

        _rb.linearVelocity = _direction.normalized * dashSpeed;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_moveCompleted) return;

        _dashTimer += Time.fixedDeltaTime;

        Vector2 toTarget = _target - _startPosition;
        Vector2 traveled = _rb.position - _startPosition;

        bool reachedTarget = Vector2.Dot(traveled, toTarget) >= toTarget.sqrMagnitude;
        bool timeFinished = _dashTimer >= _duration;

        if (reachedTarget || timeFinished)
        {
            FinishDash();
        }
    }

    protected virtual void FinishDash()
    {
        _rb.linearVelocity = Vector2.zero;
        _rb.position = _target;

        _moveCompleted = true;
    }

    public override void Exit()
    {
        base.Exit();

        if (_rb != null)
            _rb.linearVelocity = Vector2.zero;
    }
}