using UnityEngine;

public class EnemyContext
{
    public EnemyVisualController VisualController { get; private set; }
    
    public EnemyContext(EnemyVisualController visualController)
    {
        VisualController = visualController;
    }
}