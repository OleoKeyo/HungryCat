using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    public GameObject[] elements;
    public GameObject a;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SpawnElements", 2.0f);
        SpawnElements();
        
        
    }

    void SpawnElements()
    {
         int elementIndex = Random.Range(0, elements.Length);
         Vector2 spawnPos = gameObject.transform.position;
         Instantiate(elements[elementIndex], spawnPos, elements[elementIndex].transform.rotation);
    }
}
