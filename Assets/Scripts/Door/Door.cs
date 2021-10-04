using Config;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public LevelTransferTrigger levelTransferTrigger;
    public DoorsConfig doorsConfig;
    
    private ElementType _elementToOpenDoor;

    private void Awake()
    {
        levelTransferTrigger.gameObject.SetActive(false);
    }

    public void SetRightDoorElement(ElementType element)
    {
        _elementToOpenDoor = element;
        spriteRenderer.sprite = doorsConfig.GetDoorSprite(element);
    }

    public void CheckAnswer(ElementType elementType)
    {
        if (elementType == _elementToOpenDoor)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        FadeDoor();
        levelTransferTrigger.gameObject.SetActive(true);
    }

    private void FadeDoor()
    {
        Color oldColor = spriteRenderer.color;
        Color newColor = oldColor;
        newColor.a = 0f;
        spriteRenderer.color = newColor;
    }
}
