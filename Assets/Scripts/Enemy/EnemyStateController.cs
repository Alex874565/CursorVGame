using System;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private EnemyState _initialState;
    
    private EnemyContext _enemyContext;
    private EnemyStateMachine _enemyStateMachine;
    
    private void Awake()
    {
        _enemyContext = new EnemyContext(GetComponent<EnemyVisualController>());
        _enemyStateMachine = new EnemyStateMachine(_enemyContext, _initialState);
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