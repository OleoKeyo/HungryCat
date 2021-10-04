using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cat : MonoBehaviour
{
    [SerializeField] ElementType correctElement; // �������, ������� ������� ����� ��� �������� �����
    List<IAbility> abilities = new List<IAbility>(); 

    void Start()
    {
        EventManager.OnCatInteractEvent += CheckElement;
    }

    private void CheckElement(ElementType elementType)
    {
        if (elementType == correctElement)
        {
            EventManager.OnCorrectElementGivenEvent?.Invoke(transform);
            EventManager.OnTransitionToNewStage?.Invoke();
            return;
        }

        switch(elementType)
        {
            case ElementType.Fire:
                Debug.Log("������� �����");
                // abilities.Add(FireAbility)
                break;
            case ElementType.Water:
                Debug.Log("������� ��� �����");
                // abilities.Add(WaterAbility)
                break;
            case ElementType.FireAcid:
                Debug.Log("������ �����");
                // abilities.Add(AirAbility)
                break;
        }

        EventManager.OnIncorrectElementGivenEvent?.Invoke(transform);
        // abilities.Last().CastAbility()
    }

    private void OnDisable()
    {
        EventManager.OnCatInteractEvent -= CheckElement;
    }
}
