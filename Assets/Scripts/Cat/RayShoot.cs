using System;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    
    public void ShootTowards(Vector3 from, Vector3 to)
    {
        Vector3 shootDir = (to - from).normalized;
        transform.right = shootDir;
    }

    public void Update()
    {
        rigidbody2D.velocity = transform.right * speed;
    }
}
