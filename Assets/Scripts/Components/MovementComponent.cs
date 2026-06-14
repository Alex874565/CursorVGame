using System.Collections.Generic;
using UnityEngine;

public abstract class MovementComponent : MonoBehaviour
{
    protected Vector2 moveTarget;
    
    public abstract void Subscribe(List<object> subjects);
    protected abstract void Move();
}