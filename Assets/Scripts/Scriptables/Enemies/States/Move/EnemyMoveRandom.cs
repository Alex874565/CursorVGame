using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMoveRandom", menuName = "Scriptables/Enemies/States/Move/Random")]
public class EnemyMoveRandom : EnemyMove
{
    [SerializeField] private float _range;
    
    public override void Enter()
    {
        base.Enter();

        Vector2 direction = Random.insideUnitCircle;

        if (direction.sqrMagnitude < 0.001f)
            direction = Vector2.right;

        direction.Normalize();

        float maxRange = _context.CollisionController.GetMaxRangeInDirection(direction);
        maxRange = Mathf.Min(maxRange, _range);

        _target = _context.CollisionController.Rb.position + direction * maxRange;
    }

    public override void FixedUpdate()
    {
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
            RollNextState();
        }
    }
}