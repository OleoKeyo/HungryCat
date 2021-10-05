using System.Collections;
using Config;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public LevelTransferTrigger levelTransferTrigger;
    public DoorsConfig doorsConfig;
    private const string BeamTag = "Beam"; 
    private const string ShootTag = "Shoot";
    
    private ElementType _elementToOpenDoor;

    [Header("sound properties")]
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failSound;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        levelTransferTrigger.gameObject.SetActive(false);
    }

    public void SetRightDoorElement(ElementType element)
    {
        _elementToOpenDoor = element;
        spriteRenderer.sprite = doorsConfig.GetDoorSprite(element);
    }
    
    public void CheckElementType(ElementType elementType)
    {
        Debug.Log($"{elementType.ToString()} {_elementToOpenDoor.ToString()}");
        if (elementType == _elementToOpenDoor)
        {
            OpenDoor();
            _audioSource.clip = successSound;
        }
        else
        {
            _audioSource.clip = failSound;
        }
        _audioSource.Play();
    }

    private void OpenDoor()
    {
        StartCoroutine(FadeDoor());
    }

    private IEnumerator FadeDoor()
    {
        while (spriteRenderer.color.a > 0)
        {
            Color oldColor = spriteRenderer.color;
            Color newColor = oldColor;
            newColor.a -= 0.03f;
            spriteRenderer.color = newColor;
            yield return new WaitForSeconds(0.03f);
            levelTransferTrigger.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BeamTag))
        {
            var beam = other.GetComponent<Beam>();
            if (beam != null)
            {
                CheckElementType(beam.type);
                return;
            }
        }
        if (other.CompareTag(ShootTag))
        {
            
            var rayShoot = other.GetComponent<RayShoot>();
            if (rayShoot != null)
            {
                CheckElementType(rayShoot.type);
            }
        }
    }
}
