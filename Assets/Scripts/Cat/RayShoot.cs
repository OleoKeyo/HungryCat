using System;
using AlchemyCat.Player;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    public Rigidbody2D rbody2D;
    public float speed;
    public ElementType type;
    private const string PlayerTag = "Player";
    private const string DoorTag = "Door";

    private float _livetime = 10f;
    private float _livetimeEnd;
    private AudioSource _audioSource;

    private Vector3 _shootDir;
    
    private void OnEnable()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        _livetimeEnd = _livetime;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void ShootTowards(Vector3 from, Vector3 to)
    {
        Vector3 shootDir = (to - from).normalized;
        _shootDir = shootDir;
        transform.right = shootDir;
        rbody2D.AddForce(shootDir);
    }

    public void Update()
    {
        _livetimeEnd -= Time.deltaTime;
        if (_livetimeEnd <= 0f)
        {
            Destroy(gameObject);
        }
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
            var player = other.GetComponent<PlayerHealth>();
            player.TakeDamage(type);
            Debug.Log("PlayerHit");
        }
        
    }
}
