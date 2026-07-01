using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMoveRandom", menuName = "Scriptables/Enemies/States/Move/Random")]
public class EnemyMoveRandom : EnemyMove
{
    [SerializeField] private float _range;
    
    public override void Enter()
    {
        base.Enter();

        _moveCompleted = false;
        _timer = 0;
        
        Vector2 direction = Random.insideUnitCircle;

        if (direction.sqrMagnitude < 0.001f)
            direction = Vector2.right;

        direction.Normalize();

        float maxRange = _context.CollisionController.GetMaxRangeInDirection(direction);
        maxRange = Mathf.Min(maxRange, _range);

        _target = _context.CollisionController.Rb.position + direction * maxRange;
    }

    public override void Update()
    {
        base.Update();
        
        if (_moveCompleted)
        {
            _timer += Time.fixedDeltaTime;
            if (_timer >= _waitTimeAfterMove)
            {
                RollNextState();
            }
        }
    }
}