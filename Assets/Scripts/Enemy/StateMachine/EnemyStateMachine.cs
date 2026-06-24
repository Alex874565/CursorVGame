using System;

public class EnemyStateMachine
{
    private EnemyContext _enemyContext;
    private EnemyState _currentState;
    
    public EnemyStateMachine(EnemyContext enemyContext, EnemyState initialState)
    {
        _enemyContext = enemyContext;
        ChangeState(initialState);
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void FixedUpdate()
    {
        _currentState.FixedUpdate();
    }

    public void LateUpdate()
    {
        _currentState.LateUpdate();
        
        EnemyState nextState = _currentState.NextState();
        if(nextState != null)
        {
            ChangeState(nextState);
        }
    }
    
    private void ChangeState(EnemyState state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;
        _currentState.Initialize(_enemyContext);
        _currentState.Enter();
    }
}