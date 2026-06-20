using UnityEngine;

public class ProjectileFactory : Factory
{
    public static ProjectileFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    
    public override GameObject CreateObject(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        GameObject projectile = Instantiate(prefab, position, rotation);
        return projectile;
    }
}