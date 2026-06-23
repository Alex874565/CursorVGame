using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class EnemyVisualController : MonoBehaviour
{
    [SerializeField] private List<CellRow> _cellRows;
    
    public void TelegraphAction(Color color, List<Vector2> positions, int count, float flashTime)
    {
        foreach (Vector2 position in positions)
        {
            SpriteRenderer cell = _cellRows[(int)position.x].Cells[(int)position.y];
            FlashCell(cell, color, count, flashTime);
        }
    }

    public void FlashCell(SpriteRenderer cell, Color color, int count, float flashTime)
    {
        Color originalColor = cell.color;

        cell.DOKill();

        cell.DOColor(color, flashTime)
            .SetLoops(count * 2, LoopType.Yoyo)
            .OnComplete(() => cell.color = originalColor);
    }
    
    [System.Serializable]
    private class CellRow
    {
        public List<SpriteRenderer> Cells;
    }
}