using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject
{
    [field: SerializeField] public ActionType ActionType { get; protected set; }
    [Header("Telegraph")]
    [field: SerializeField] public Color TelegraphColor { get; protected set; }
    [field: SerializeField] public int TelegraphCount { get; protected set; }
    [field: SerializeField] public float TelegraphFlashTime { get; protected set; }
    [field: SerializeField] public List<Vector2> TelegraphCells { get; protected set; }

    public void Execute(EnemyVisualController visualController)
    {
        visualController.TelegraphAction(TelegraphColor, TelegraphCells, TelegraphCount, TelegraphFlashTime);
    }
}