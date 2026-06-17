using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Scriptables/Weapons")]
public abstract class Weapon : ScriptableObject
{
    [field: SerializeField] public float Damage { get; protected set; }
    [field: SerializeField] public float LoadTime { get; protected set; }
    [field: SerializeField] public float ReloadTime { get; protected set; }
    [field: SerializeField] public float Speed { get; protected set; }
    [field: SerializeField] public Sprite Sprite { get; protected set; }
    [field: SerializeField] public GameObject ProjectilePrefab { get; protected set; }
}