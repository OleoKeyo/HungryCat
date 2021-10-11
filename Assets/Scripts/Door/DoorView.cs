using System.Collections;
using AlchemyCat.Cat;
using AlchemyCat.Infrastructure.Factory;
using AlchemyCat.Infrastructure.Services.StaticData;
using Config;
using UnityEngine;

[RequireComponent(typeof(DoorAudio))]
[RequireComponent(typeof(SpriteRenderer))]
public class DoorView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private IGameFactory _gameFactory;
    private LevelTransferData _levelTransferData;
    private ElementType _elementToOpenDoor;
    private DoorAudio _audio;
    private bool _isOpened;
    
    public void Construct(LevelTransferData levelTransferData, IGameFactory gameFactory, ElementType elementType, Sprite doorSprite)
    {
        _gameFactory = gameFactory;
        _levelTransferData = levelTransferData;
        _elementToOpenDoor = elementType;
        _audio = GetComponent<DoorAudio>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = doorSprite;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_isOpened)
            return;
        IAttack attack = other.GetComponent<IAttack>();
        if (attack != null)
        {
            ElementType element = attack.GetElementType();
            CheckElementType(element);
        }
    }
    
    public void CheckElementType(ElementType elementType)
    {
        if(_isOpened)
            return;
        
        Debug.Log($"{elementType.ToString()} {_elementToOpenDoor.ToString()}");
        if (elementType == _elementToOpenDoor)
            OpenDoor();
        else
            OpenFail();
    }

    private void OpenDoor()
    {
        _isOpened = true;
        _audio.PlaySuccess();
        StartCoroutine(FadeDoor());
    }

    private void OpenFail() => 
        _audio.PlayFail();


    private IEnumerator FadeDoor()
    {
        while (_spriteRenderer.color.a > 0)
        {
            Color oldColor = _spriteRenderer.color;
            Color newColor = oldColor;
            newColor.a -= 0.03f;
            _spriteRenderer.color = newColor;
            yield return new WaitForSeconds(0.03f);
        }
        _gameFactory.CreateLevelTransformTrigger(_levelTransferData);
    }
}
