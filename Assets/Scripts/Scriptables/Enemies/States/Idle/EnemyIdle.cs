using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIdle", menuName = "Scriptables/Enemies/States/Idle")]
public class EnemyIdle : EnemyState
{
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;

    private float _duration;

    public override void Enter()
    {
        base.Enter();
        _duration = Random.Range(_minDuration, _maxDuration);
    }

    public override void Update()
    {
        if (_duration > 0)
        {
            _duration -= Time.deltaTime;
        }
        else
        {
            RollNextState();
        }
    }
}