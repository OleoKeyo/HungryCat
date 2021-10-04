using System;
using System.Collections;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private const string DoorTag = "Door";
    
    public float rotationSpeed = 30;
    public float countdownToAttack = 2f;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public ElementType type;

    private bool _triggered;
    private bool readyToAttack;

    private void Awake()
    {
        IsEnable(false);
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }

    public void IsEnable(bool isEnable)
    {
        spriteRenderer.enabled = isEnable;
        boxCollider.enabled = isEnable;
        if(isEnable)
            StartCoroutine(CountdownToAttack());
    }

    private IEnumerator CountdownToAttack()
    {
        yield return new WaitForSeconds(countdownToAttack);
        readyToAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag(DoorTag) && readyToAttack)
        {
            var door = other.GetComponent<Door>();
            door.CheckElementType(type);
            Debug.Log("DoorHit");
        }
        
        if (other.CompareTag(PlayerTag) && readyToAttack)
        {
            Debug.Log("PlayerHit");
        }
    }
}
