using UnityEngine;

namespace AlchemyCat.Cat
{
  public class BeamWeapon: MonoBehaviour
  {
    public RotateAround rotate;
    public Beam beamPrefab;
    private int _activeBeams;
    private Transform _playerTransform;
    private int _lastBeamRotation;
    
    public void Construct(Transform playerTransform)
    {
      _playerTransform = playerTransform;
    }
    
    private void RotateWeapon()
    {
      Vector3 playerDirection = transform.position - _playerTransform.position ;
      playerDirection.Normalize();
      Quaternion rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
      transform.rotation = rotation;
      rotate.enabled = true;
    }
    
    public void EnableBeamAttack(ElementType type)
    {
      if (_activeBeams == 0)
        RotateWeapon();
        
      _activeBeams++;
      ShowBeam();
    }
    
    private void ShowBeam()
    {
      var beam = Instantiate(beamPrefab, transform, false);
      var beamTransform = beam.GetComponent<Transform>();
      int rotationCoef = _activeBeams % 2 == 0 ? 180 : -90;
      int beamZRotation = _lastBeamRotation + rotationCoef;
      _lastBeamRotation = beamZRotation;
      beamTransform.localRotation = Quaternion.Euler(0,0, beamZRotation);
    }
  }
}