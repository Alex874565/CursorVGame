using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WeaponController : MonoBehaviour, IShoot
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private SpriteRenderer _weaponRenderer;
    
    private Factory _projectileFactory;
    private PlayerInputController _playerInputController;
    
    private float _radius;

    private void Awake()
    {
        _radius = _weaponTransform.localPosition.magnitude;
    }
    
    public void Initialize(List<object> subjects)
    {
        foreach (var subject in subjects)
        {
            if (subject is PlayerInputController inputController)
            {
                _playerInputController = inputController;
                inputController.OnMoveCursor += PointAt;
            }
        }
    }
    
    public void ChangeWeapon(Weapon newWeapon)
    {
        _weapon = newWeapon;
        _weaponRenderer.sprite = _weapon.Sprite;
    }

    public void OnDestroy()
    {
        if (_playerInputController != null)
        {
            _playerInputController.OnMoveCursor -= PointAt;
        }
    }

    public void Shoot()
    {
        _projectileFactory.CreateObject(_weapon.ProjectilePrefab, transform.position, transform.rotation);
    }

    private void PointAt(Vector2 direction)
    {
        direction.Normalize();

        _weaponTransform.localPosition = direction * _radius;
        _weaponTransform.right = direction;
    }

}