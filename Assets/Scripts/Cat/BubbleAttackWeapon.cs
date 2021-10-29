using System;
using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace AlchemyCat.Cat
{
  public class BubbleAttackWeapon : MonoBehaviour
  {
    public Target bubbleTargetPrefab;
    public GameObject bubbleShootPrefab;
    public Transform spawnShootPoint;

    private Transform _playerTransform;
    private GameTilemap _map;
    
    private DateTime _lastBubbleAttack;
    private int _activeBubble;
    private int _bubbleAttackRadius = 2;
    private int _bubbleAttackCount = 3;
    private float startShotsCooldown = 3f;

    public void Construct(Transform playerTransform, GameTilemap map)
    {
      _playerTransform = playerTransform;
      _map = map;
    }

    private void Update() =>
      BubbleAttackUpdate();
    
    public void EnableBubbleAttack(ElementType elementType)
    {
      _activeBubble++;
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

    private void BubbleAttack(Vector3 playerPosition)
    {
      List<Vector3> shotPositions = _map.GetFreeRandomPoints(playerPosition, _bubbleAttackRadius, _bubbleAttackCount);

      foreach (Vector3 shotPosition in shotPositions)
        CreateBubbleAttack(shotPosition);
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
}