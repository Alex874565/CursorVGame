using UnityEngine;

public class ProjectileFactory : Factory
{
    public override GameObject CreateObject(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        GameObject projectile = Instantiate(prefab, position, rotation);
        return projectile;
    }
}