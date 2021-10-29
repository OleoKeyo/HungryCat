using System;
using UnityEngine;

namespace AlchemyCat.Cat
{
  public class RayShootWeapon : MonoBehaviour
  {
    public GameObject rayShootPrefab;
    public Transform spawnShootPoint;
    
    private int _activeShots;
    private float _startShotsCooldown = 3f;
    private DateTime _lastRayFire;
    private Transform _playerTransform;

    public void Construct(Transform playerTransform)
    {
      _playerTransform = playerTransform;
    }

    public void EnableShoot()
    {
      _activeShots++;
    }

    private void Update()
    {
      if (_activeShots <= 0)
        return;

      float shotsCooldown = _startShotsCooldown / _activeShots;
      if (DateTime.Now - _lastRayFire < TimeSpan.FromSeconds(shotsCooldown))
        return;

      _lastRayFire = DateTime.Now;
      RayShoot(_playerTransform.position);
    }

    private void RayShoot(Vector3 playerPosition)
    {
      Vector3 playerDirection = transform.position - playerPosition;
      playerDirection.Normalize();
        
      Quaternion rotation = Quaternion.FromToRotation(Vector3.right, playerDirection);
      Instantiate(rayShootPrefab, spawnShootPoint.position, rotation, spawnShootPoint);
    }
  }
}