using System;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class EnemyVisualController : MonoBehaviour
{
    [SerializeField] private List<CellRow> _cellRows;

    private Color _initialColor;

    private void Awake()
    {
        if (_cellRows.Count == 0 || _cellRows[0].Cells.Count == 0)
        {
            _initialColor = Color.white;
        }
        else
        {
            _initialColor = _cellRows[0].Cells[0].color;
        }
    }

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
        Sequence seq = DOTween.Sequence();

        for (int i = 0; i < count; i++)
        {
            seq.Append(cell.DOColor(color, flashTime));
            seq.Append(cell.DOColor(_initialColor, flashTime));
        }
    }
    
    [System.Serializable]
    private class CellRow
    {
        public List<SpriteRenderer> Cells;
    }
}