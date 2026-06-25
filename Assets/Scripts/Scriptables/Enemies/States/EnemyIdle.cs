using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIdle", menuName = "Scriptables/Enemies/States/Idle")]
public class EnemyIdle : EnemyState
{
    [SerializeField] private List<EnemyAttack> attacks;

    private float _dice;
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        _dice = Random.Range(0f, 100f);
    }

    public override EnemyState NextState()
    {
        if (_dice <= _enemyContext.EnemyData.AttackChance)
        {
            return attacks[Random.Range(0, attacks.Count)];
        }
        else if (_dice <= _enemyContext.EnemyData.AttackChance + _enemyContext.EnemyData.MoveChance)
        {
            //return _enemyContext.MoveState;
        }
        else if (_dice <= _enemyContext.EnemyData.AttackChance + _enemyContext.EnemyData.MoveChance + _enemyContext.EnemyData.DashChance)
        {
            //return _enemyContext.DashState;
        }
        else
        {
            
        }

        return null;
    }
    
}