using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public abstract GameObject CreateObject(GameObject prefab, Vector2 position, Quaternion rotation);
}