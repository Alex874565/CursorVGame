using UnityEngine;

public class EnemyContext
{
    public EnemyVisualController VisualController { get; private set; }
    public EnemyData EnemyData { get; private set; }
    
    public EnemyContext(EnemyData data, EnemyVisualController visualController)
    {
        VisualController = visualController;
        EnemyData = data;
    }
}