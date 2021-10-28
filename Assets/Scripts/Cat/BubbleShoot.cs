using System.Collections;
using AlchemyCat.Cat;
using UnityEngine;

public class BubbleShoot : MonoBehaviour, IAttack
{
    private const float MinimalDistance = 0.1f;
    
    public float speed;
    public CircleCollider2D damageZone;
    public ElementType elementType;

    private Transform _transform;
    private Vector3 _endPosition;
    private Vector3 _direction;
    
    public void ShootTowards(Vector3 endPosition)
    {
        _transform = transform;
        _endPosition = endPosition;
        _direction = endPosition - _transform.position;
        _direction.Normalize();
    }

    public void Update()
    {
        if (!DestinationIsReached())
            _transform.Translate(_direction * speed * Time.deltaTime);
        else
            StartCoroutine(Fire(0.5f));
    }

    private IEnumerator Fire(float time)
    {
        damageZone.enabled = true;
        while (_transform.localScale.x < 1)
        {
            var newScale = _transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
            transform.localScale = newScale;
            yield return new WaitForSeconds(time / 8);
        }
        
        StartCoroutine(DestroyTimer(0.2f));
    }

    private IEnumerator DestroyTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    public ElementType GetElementType() => 
        elementType;

    private bool DestinationIsReached()
    {
        Vector3 distance = _transform.position - _endPosition;
        return distance.sqrMagnitude <= MinimalDistance;
    }
}
