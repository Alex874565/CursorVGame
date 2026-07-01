using UnityEngine;

public class EnemyMove : EnemyState
{
    protected Vector2 _target;

    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        Vector2 current = _context.CollisionController.Rb.position;

        _context.CollisionController.Rb.MovePosition(
            Vector2.MoveTowards(
                current,
                _target,
                _context.Data.MovementSpeed * Time.fixedDeltaTime
            )
        );

        if (Vector2.Distance(current, _target) < 0.05f)
        {
            _moveCompleted = true;
        }
    }
}