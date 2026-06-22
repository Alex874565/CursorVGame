using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    
    public void AddImpulse(Vector3 direction, float force)
    {
        _rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}