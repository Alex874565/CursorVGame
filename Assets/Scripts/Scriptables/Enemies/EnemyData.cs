using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptables/Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [Header("Chances")]
    [field: SerializeField] public float AttackChance { get; private set; }
    [field: SerializeField] public float MoveChance { get; private set; }
    [field: SerializeField] public float DashChance { get; private set; }
}