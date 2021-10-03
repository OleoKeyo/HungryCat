using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Awake()
    {
        EventManager.OnTransitionToNewStage += SetActive;
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }

    void Start()
    {
        EventManager.OnCorrectElementGivenEvent += DestroyDoor;
    }

    private void DestroyDoor(Transform obj)
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        EventManager.OnCorrectElementGivenEvent -= DestroyDoor;
        EventManager.OnTransitionToNewStage -= SetActive;
    }
}
