public class EnemyContext
{
    public EnemyVisualController VisualController { get; private set; }
    public EnemyData Data { get; private set; }
    
    public EnemyCollisionController CollisionController { get; private set; }
    
    public EnemyContext(EnemyData data, EnemyVisualController visualController, EnemyCollisionController collisionController)
    {
        VisualController = visualController;
        CollisionController = collisionController;
        Data = data;
    }
}