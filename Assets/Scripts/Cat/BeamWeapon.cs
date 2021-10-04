using UnityEngine;

public class BeamWeapon : MonoBehaviour
{
    public Beam acidBeam;
    public Beam fireBeam;
    public Beam waterBeam;

    public void EnableAcidBeam() => 
        acidBeam.IsEnable(true);
    
    public void EnableFireBeam() => 
        fireBeam.IsEnable(true);
    
    public void EnableWaterBeam() => 
        waterBeam.IsEnable(true);
    
    public void FireWaterShoot()
    {
    }

    public void FireAcidShoot()
    {
    }

    public void WaterAcidShoot()
    {
    }
}
