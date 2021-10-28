using System;
using System.Collections;
using System.Collections.Generic;
using AlchemyCat.Cat;
using Logic;
using UnityEngine;

public class BeamWeapon : MonoBehaviour
{
    public RotateAround rotate;
    public Beam beamPrefab;

    public AoEAttack aoeAttackPrefab;
    
    public GameObject rayAttackPrefab;
    public Transform spawnShootPoint;

    public Target bubbleTargetPrefab;
    public GameObject bubbleShootPrefab;

    private int _activeShots;
    private float startShotsCooldown = 3f;
    private DateTime _lastRayFire;
    private Transform _playerTransform;

    private int _activeBeams;
    private int _lastBeamRotation;
    private GameTilemap _map;

    private DateTime _lastAoeFire;
    private int _activeAoe;
    private int _aoeShootRadius = 0;
    private int _aotShootsCount = 1;

    private DateTime _lastBubbleAttack;
    private int _activeBubble;
    private int _bubbleAttackRadius = 2;
    private int _bubbleAttackCount = 3;
    
    public void Construct(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _map = FindObjectOfType<GameTilemap>();
    }

    private void Update()
    {
        RayShootUpdate();
        AoeShootUpdate();
        BubbleAttackUpdate();
    }

    private void AoeShootUpdate()
    {
        if (_activeAoe <= 0)
            return;

        float shotsCooldown = startShotsCooldown / _activeAoe;
        
        if(DateTime.Now - _lastAoeFire < TimeSpan.FromSeconds(shotsCooldown))
            return;
        
        _lastAoeFire = DateTime.Now;
        AoeShoot(_playerTransform.position);
    }

    private void RayShootUpdate()
    {
        if (_activeShots <= 0)
            return;

        float shotsCooldown = startShotsCooldown / _activeShots;
        if (DateTime.Now - _lastRayFire < TimeSpan.FromSeconds(shotsCooldown))
            return;

        _lastRayFire = DateTime.Now;
        RayShoot(_playerTransform.position);
    }

    private void BubbleAttackUpdate()
    {
        if(_activeBubble <= 0)
            return;

        float shotsCooldown = startShotsCooldown / _activeBubble;
        if(DateTime.Now - _lastBubbleAttack < TimeSpan.FromSeconds(shotsCooldown))
            return;
        
        _lastBubbleAttack = DateTime.Now;
        BubbleAttack(_playerTransform.position);
    }

    public void EnableBeamAttack(ElementType type)
    {
        if (_activeBeams == 0)
            RotateWeapon();
        
        _activeBeams++;
        ShowBeam();
    }

    public void EnableAoEAttack(ElementType type)
    {
        _activeAoe++;
    }
    
    public void EnableBubbleAttack(ElementType elementType)
    {
        _activeBubble++;
    }

    private void RotateWeapon()
    {
        Vector3 playerDirection = transform.position - _playerTransform.position ;
        playerDirection.Normalize();
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
        transform.rotation = rotation;
        rotate.enabled = true;
    }

    private void ShowBeam()
    {
        var beam = Instantiate(beamPrefab, transform, false);
        var beamTransform = beam.GetComponent<Transform>();
        int rotationCoef = _activeBeams % 2 == 0 ? 180 : -90;
        int beamZRotation = _lastBeamRotation + rotationCoef;
        _lastBeamRotation = beamZRotation;
        beamTransform.localRotation = Quaternion.Euler(0,0, beamZRotation);
    }

    public void AddFireWaterShoot() =>
        _activeShots++;

    public void AddFireAcidShoot() =>
        _activeShots++;

    public void AddWaterAcidShoot() =>
        _activeShots++;

    private void RayShoot(Vector3 playerPosition)
    {
        Vector3 playerDirection = transform.position - playerPosition;
        playerDirection.Normalize();
        
        Quaternion rotation = Quaternion.FromToRotation(Vector3.right, playerDirection);
        Instantiate(rayAttackPrefab, spawnShootPoint.position, rotation, spawnShootPoint);
    }

    private void AoeShoot(Vector3 playerPosition)
    {
        playerPosition.y += 0.5f;
        
        Instantiate(aoeAttackPrefab, playerPosition, Quaternion.identity);
    }

    private void BubbleAttack(Vector3 playerPosition)
    {
        List<Vector3> shotPositions = _map.GetFreeRandomPoints(playerPosition, _bubbleAttackRadius, _bubbleAttackCount);

        foreach (Vector3 shotPosition in shotPositions)
        {
            CreateBubbleAttack(shotPosition);
        }
    }

    private void CreateBubbleAttack(Vector3 shotPosition)
    {
        Instantiate(bubbleTargetPrefab, shotPosition, Quaternion.identity);
        StartCoroutine(WaitForSecondsAndShoot(1f, shotPosition, bubbleShootPrefab, 3));
    }
    
    private IEnumerator WaitForSecondsAndShoot(float waitingTime, Vector3 shotPosition, GameObject bullet, int shotsCount)
    {
        yield return new WaitForSeconds(waitingTime);
        for (int i = 0; i < shotsCount; i++)
        {
            var bulletGo = Instantiate(bullet, spawnShootPoint.position, Quaternion.identity);
            BubbleShoot bubble = bulletGo.GetComponent<BubbleShoot>();
            bubble.ShootTowards(shotPosition);
            yield return new WaitForSeconds(waitingTime/shotsCount);
        }
    }
}
