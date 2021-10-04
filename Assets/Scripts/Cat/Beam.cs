using System;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float rotationSpeed = 30;
    
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }

    public void Enable()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
