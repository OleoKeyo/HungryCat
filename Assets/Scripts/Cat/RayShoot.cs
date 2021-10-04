using System;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    public ElementType type;
    private const string PlayerTag = "Player";
    private const string DoorTag = "Door";

    public void ShootTowards(Vector3 from, Vector3 to)
    {
        Vector3 shootDir = (to - from).normalized;
        transform.right = shootDir;
    }

    public void Update()
    {
        rigidbody2D.velocity = transform.right * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag(DoorTag))
        {
            var door = other.GetComponent<Door>();
            door.CheckElementType(type);
            Debug.Log("DoorHit");
        }
        
        if (other.CompareTag(PlayerTag))
        {
            Debug.Log("PlayerHit");
        }
    }
}
