using UnityEngine;

public abstract class MovementComponent : MonoBehaviour
{
    protected Vector2 moveTarget;

    public void SetMoveTarget(Vector2 moveTarget)
    {
        this.moveTarget = moveTarget;
    }

    protected abstract void Move();
}