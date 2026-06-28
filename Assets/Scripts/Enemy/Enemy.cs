using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _data;
    
    public EnemyContext EnemyContext { get; private set; }

    private void Awake()
    {
        EnemyContext = new EnemyContext(_data,
            GetComponent<EnemyVisualController>(), 
            GetComponent<EnemyCollisionController>());
    }
}