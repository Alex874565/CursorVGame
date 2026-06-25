using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class WeaponController : MonoBehaviour, IShoot
{
    [FormerlySerializedAs("_weapon")] [SerializeField] private WeaponData weaponData;
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private SpriteRenderer _weaponRenderer;
    
    private PlayerInputController _playerInputController;
    
    private float _radius;

    private bool _isShooting;

    private Coroutine _shootingCoroutine;

    private void Awake()
    {
        _radius = _weaponTransform.localPosition.magnitude;
        ChangeWeapon(weaponData);
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
    
    public void ChangeWeapon(WeaponData newWeaponData)
    {
        weaponData = newWeaponData;
        _weaponRenderer.sprite = weaponData.Sprite;
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
        _shootingCoroutine = StartCoroutine(ShootingCoroutine());
    }

    private void StopShooting()
    {
        _weaponRenderer.enabled = false;
        if (_shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }
    }
    
    public void Shoot() 
    {
        GameObject projectile = ProjectileFactory.Instance.CreateObject(weaponData.ProjectilePrefab, transform.position, transform.rotation);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        if (projectileController != null)
        {
            projectileController.AddImpulse(transform.right, weaponData.ShootForce);
        }
    }

    private IEnumerator ShootingCoroutine()
    {
        yield return new WaitForSeconds(weaponData.LoadTime);
        do
        {
            Shoot();
            yield return new WaitForSeconds(weaponData.ReloadTime);
        } while (true);
    }

    private void PointAt(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)_weaponTransform.parent.position;

        if (direction.sqrMagnitude < 0.001f)
            return;

        direction.Normalize();

        _weaponTransform.localPosition = direction * _radius;
        _weaponTransform.right = direction;
    }
}