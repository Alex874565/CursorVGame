using UnityEngine;

public class EnemyMove : EnemyState
{
    [SerializeField] protected float _waitTimeAfterMoving;
    protected Vector2 _target;
    protected bool _moveCompleted;

    public override void Enter()
    {
        base.Enter();
        _moveCompleted = false;
    }
}