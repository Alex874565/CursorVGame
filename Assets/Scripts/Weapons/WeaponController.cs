using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour, IShoot
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private SpriteRenderer _weaponRenderer;
    
    private PlayerInputController _playerInputController;
    
    private float _radius;

    private bool _isShooting;

    private void Awake()
    {
        _radius = _weaponTransform.localPosition.magnitude;
        ChangeWeapon(_weapon);
    }
    
    public void Initialize(List<object> subjects)
    {
        foreach (var subject in subjects)
        {
            if (subject is PlayerInputController inputController)
            {
                _playerInputController = inputController;
                inputController.OnMoveCursor += PointAt;
                inputController.OnLeftClickPressed += StartShooting;
                inputController.OnLeftClickReleased += StopShooting;
            }
        }
    }
    
    public void ChangeWeapon(Weapon newWeapon)
    {
        _weapon = newWeapon;
        _weaponRenderer.sprite = _weapon.Sprite;
        _weaponRenderer.enabled = false;
    }

    public void OnDestroy()
    {
        if (_playerInputController != null)
        {
            _playerInputController.OnMoveCursor -= PointAt;
        }
    }

    private void StartShooting()
    {
        _weaponRenderer.enabled = true;
        _isShooting = true;
    }

    private void StopShooting()
    {
        _weaponRenderer.enabled = false;
        _isShooting = false;
    }

    public void Shoot() 
    {
        ProjectileFactory.Instance.CreateObject(_weapon.ProjectilePrefab, transform.position, transform.rotation);
    }

    private void PointAt(Vector2 direction)
    {
        direction.Normalize();

        _weaponTransform.localPosition = direction * _radius;
        _weaponTransform.right = direction;
    }

}