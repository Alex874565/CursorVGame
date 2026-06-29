using UnityEngine;

public class EnemyMove : EnemyState
{
    protected Vector2 _target;
    protected bool _moveCompleted;

    public override void Enter()
    {
        base.Enter();
        _moveCompleted = false;
    }
}