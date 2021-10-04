using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RayShoot : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    public ElementType type;
    private const string PlayerTag = "Player";
    private const string DoorTag = "Door";

    private float _livetime = 10f;
    private float _livetimeEnd;
    private AudioSource _audioSource;

    private void Start()
    {
        _livetimeEnd = _livetime;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _audioSource.Play();
    }

    public void ShootTowards(Vector3 from, Vector3 to)
    {
        Vector3 shootDir = (to - from).normalized;
        transform.right = shootDir;
    }

    public void Update()
    {
        _livetimeEnd -= Time.deltaTime;
        if (_livetimeEnd <= 0f)
        {
            Destroy(this);
        }

        rigidbody2D.velocity = transform.right * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag(DoorTag))
        {
            var door = other.GetComponent<Door>();
            door.CheckElementType(type);
            Debug.Log("DoorHit");
        }
        
        if (other.CompareTag(PlayerTag))
        {
            var player = other.GetComponent<Player>();
            player.Dead();
            Debug.Log("PlayerHit");
        }
        
        Destroy(this);
    }
}
