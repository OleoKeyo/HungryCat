using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeapon : MonoBehaviour
{
    public Beam acidBeam;
    public Beam fireBeam;
    public Beam waterBeam;

    public GameObject fireWaterShootPrefab;
    public GameObject fireAcidShootPrefab;
    public GameObject waterAcidShootPrefab;

    public GameObject targetEffectPrefab;

    public Transform spawnShootPoint;

    private List<GameObject> _availableShotsPrefab = new List<GameObject>();
    private int currentPrefabIndex;

    public void Construct(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void EnableAcidBeam() => 
        acidBeam.IsEnable(true);
    
    public void EnableFireBeam() => 
        fireBeam.IsEnable(true);
    
    public void EnableWaterBeam() => 
        waterBeam.IsEnable(true);
    
    public void AddFireWaterShoot()
    {
        if(_availableShotsPrefab.Contains(fireWaterShootPrefab))
            return;
        _availableShotsPrefab.Add(fireWaterShootPrefab);
    }

    public void AddFireAcidShoot()
    {
        if(_availableShotsPrefab.Contains(fireAcidShootPrefab))
            return;
        _availableShotsPrefab.Add(fireAcidShootPrefab);
    }

    public void AddWaterAcidShoot()
    {
        if(_availableShotsPrefab.Contains(waterAcidShootPrefab))
            return;
        _availableShotsPrefab.Add(waterAcidShootPrefab);
    }

    private DateTime _lastFire;
    private Transform _playerTransform;

    private void Update()
    {
        if(_availableShotsPrefab.Count == 0)
            return;

        if (DateTime.Now - _lastFire < TimeSpan.FromSeconds(2)) 
            return;
        
        _lastFire = DateTime.Now;
        Shoot(_playerTransform.position);
    }

    private void Shoot(Vector3 playerPosition)
    {
        GameObject bullet = _availableShotsPrefab[currentPrefabIndex];
        currentPrefabIndex++;
        if (currentPrefabIndex >= _availableShotsPrefab.Count)
            currentPrefabIndex = 0;
        
        Instantiate(targetEffectPrefab, playerPosition, Quaternion.identity);
        StartCoroutine(WaitForSecondsAndShoot(1f, playerPosition, bullet));
    }

    private IEnumerator WaitForSecondsAndShoot(float waitingTime, Vector3 playerPosition, GameObject bullet)
    {
        yield return new WaitForSeconds(waitingTime);
        var bulletGo = Instantiate(bullet, spawnShootPoint.position, Quaternion.identity);
        RayShoot ray = bulletGo.GetComponent<RayShoot>();
        ray.ShootTowards(spawnShootPoint.position, playerPosition);
    }
    
}
