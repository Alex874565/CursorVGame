using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }
    [SerializeField] private LayerMask wallLayer;

    private Collider2D _collider;
    
    private readonly RaycastHit2D[] _hits = new RaycastHit2D[1];
    private ContactFilter2D _filter;
    
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        
        _filter.SetLayerMask(wallLayer);
        _filter.useTriggers = false;
    }
    
    public float GetMaxRangeInDirection(Vector3 direction)
    {
        int hitCount = _collider.Cast(direction.normalized, _filter, _hits, Mathf.Infinity);

        return hitCount > 0 ? _hits[0].distance : Mathf.Infinity;
    }
}