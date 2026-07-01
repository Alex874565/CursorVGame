using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDashRandom", menuName = "Scriptables/Enemies/States/Dash/EnemyDashRandom")]
public class EnemyDashRandom : EnemyDash
{
    public override void Enter()
    {
        base.Enter();

        _direction = Random.insideUnitCircle;

        if (_direction.sqrMagnitude < 0.001f)
            _direction = Vector2.right;

        _direction.Normalize();

        float maxRange = _context.CollisionController.GetMaxRangeInDirection(_direction);
        maxRange = Mathf.Min(maxRange, _range);

        _target = _rb.position + _direction * maxRange;

        StartDash();
    }
}