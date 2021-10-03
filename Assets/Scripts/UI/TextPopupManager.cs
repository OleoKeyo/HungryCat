using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopupManager : MonoBehaviour
{
    [SerializeField] private GameObject textPopupPrefab;
    [SerializeField] private float indentation = 5f;
    [SerializeField] private float timeToDestroyPopup = 2f;
    [SerializeField] string[] goodLines;
    [SerializeField] string[] badLines;

    void Start()
    {
        EventManager.OnCorrectElementGivenEvent += SpawnGoodPopup;
        EventManager.OnIncorrectElementGivenEvent += SpawnBadPopup;
    }

    private void SpawnGoodPopup(Transform objTransform)
    {
        SpawnPopup(objTransform, goodLines);
    }

    private void SpawnBadPopup(Transform objTransform)
    {
        SpawnPopup(objTransform, badLines);
    }

    private void SpawnPopup(Transform objTransform, string[] lines)
    {
        GameObject instance = Instantiate(textPopupPrefab, objTransform.position + Vector3.up * indentation, Quaternion.identity);
        TextMeshProUGUI textMesh = instance.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = PickRandomLine(lines);
        Destroy(instance, timeToDestroyPopup);
    }

    private string PickRandomLine(string[] lines)
    {
        return lines[Random.Range(0, lines.Length)];
    }
}
