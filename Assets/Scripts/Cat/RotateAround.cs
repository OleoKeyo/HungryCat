using UnityEngine;

namespace AlchemyCat.Cat
{
  public class RotateAround : MonoBehaviour
  {
    public float rotationSpeed = 30;
    
    void Update()
    {
      transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }
  }
}