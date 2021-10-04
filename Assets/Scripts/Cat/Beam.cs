using UnityEngine;

public class Beam : MonoBehaviour
{
    public float rotationSpeed = 30;
    
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
