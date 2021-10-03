using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] Transform endMarker;
    [SerializeField] float lerpTime = 3;

    private bool startTransition = false;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnTransitionToNewStage += Transit;
    }

    private void Transit()
    {
        startTransition = true;
        Debug.Log("Transit");
    }

    void Update()
    {
        if (startTransition)
        {
            currentTime += Time.deltaTime;

            if (currentTime > lerpTime)
            {
                currentTime = lerpTime;
            }

            float lerpRatio = currentTime / lerpTime;

            // –азобратьс€ почему так быстро передвигает камеру
            transform.position = Vector3.Lerp(transform.position, endMarker.position, lerpRatio);
        }
    }
}
