using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ElementType DoorType;
    public ElementType ElementToOpenDoor;
    
    private void Awake()
    {
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }

    void Start()
    {
    }
    
}
