using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptables/Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }

    [Header("Chances")]
    [field: SerializeField]
    public float AttackChance { get; private set; }

    [field: SerializeField] public float MoveChance { get; private set; }
    [field: SerializeField] public float DashChance { get; private set; }

    [Header("Actions")] 
    [field: SerializeField] public List<EnemyIdle> Idles { get; private set; }
    [field: SerializeField] public List<EnemyMove> Moves { get; private set; }
    [field: FormerlySerializedAs("<Dashed>k__BackingField")] [field: SerializeField] public List<EnemyDash> Dashes { get; private set; }
    [field: SerializeField] public List<EnemyAttack> Attacks { get; private set; }
}