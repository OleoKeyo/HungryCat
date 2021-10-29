using System;
using UnityEngine;

namespace AlchemyCat.Cat
{
  public class AoeWeapon : MonoBehaviour
  {
    public AoeAttack aoeAttackPrefab;
    
    private int _activeAoe;
    private float startShotsCooldown = 3f;
    private DateTime _lastAoeFire;
    private Transform _playerTransform;
    
    public void Construct(Transform playerTransform)
    {
      _playerTransform = playerTransform;
    }
    
    private void Update()
    {
      if (_activeAoe <= 0)
        return;

      float shotsCooldown = startShotsCooldown / _activeAoe;
        
      if(DateTime.Now - _lastAoeFire < TimeSpan.FromSeconds(shotsCooldown))
        return;
        
      _lastAoeFire = DateTime.Now;
      AoeShoot(_playerTransform.position);
    }
    
    private void AoeShoot(Vector3 playerPosition)
    {
      playerPosition.y += 0.5f;
        
      Instantiate(aoeAttackPrefab, playerPosition, Quaternion.identity);
    }

    public void EnableAoEAttack(ElementType elementType)
    {
      _activeAoe++;
    }
  }
}