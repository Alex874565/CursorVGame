using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }
    
    [SerializeField] private LayerMask wallLayer;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    
    public float GetMaxRangeInDirection(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, wallLayer);
        if (hit.collider != null)
        {
            return hit.distance;
        }
        return Mathf.Infinity;
    }
}