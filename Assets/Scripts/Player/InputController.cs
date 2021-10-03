using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController 
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
            EventManager.TryToInteractEvent?.Invoke();
    }
}
