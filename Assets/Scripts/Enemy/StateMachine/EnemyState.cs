using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EnemyState", menuName = "Scriptables/Enemies/State")]
public class EnemyState : ScriptableObject
{ 
    [SerializeField] private TelegraphPattern telegraphPattern;
    
    private EnemyContext _enemyContext;
    private EnemyStateMachine _enemyStateMachine;
    
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

    public void Exit()
    {
        
    }
    
    public EnemyState NextState()
    {
        return null;
    }
}