using System;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private EnemyState _initialState;
    
    private EnemyStateMachine _enemyStateMachine;
    
    private void Awake()
    {
        Enemy enemy = GetComponent<Enemy>();
        _enemyStateMachine = new EnemyStateMachine(enemy.EnemyContext, _initialState);
    }

    private void Update()
    {
        _enemyStateMachine?.Update();
    }

    private void FixedUpdate()
    {
        _enemyStateMachine?.FixedUpdate();
    }

    private void LateUpdate()
    {
        _enemyStateMachine?.LateUpdate();
    }
}