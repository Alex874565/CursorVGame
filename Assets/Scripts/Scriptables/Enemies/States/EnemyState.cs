using UnityEngine;
using UnityEngine.Serialization;

public class EnemyState : ScriptableObject
{ 
    [SerializeField] private TelegraphPattern telegraphPattern;
    
    protected EnemyContext _enemyContext;
    protected EnemyStateMachine _enemyStateMachine;
    
    public void Initialize(EnemyContext enemyContext)
    {
        if(_enemyContext == null)
            _enemyContext = enemyContext;
    }
    
    public virtual void Enter()
    {
        telegraphPattern?.Execute(_enemyContext.VisualController);
    }
    
    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {
        
    }

    public virtual void Exit()
    {
        
    }
    
    public virtual EnemyState NextState()
    {
        return null;
    }
}