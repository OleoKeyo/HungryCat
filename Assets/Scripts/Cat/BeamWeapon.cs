using UnityEngine;

public class BeamWeapon : MonoBehaviour
{
    public Beam acidBeam;
    public Beam fireBeam;
    public Beam waterBeam;

    public void EnableAcidBeam() => acidBeam.Enable();
    public void EnableFireBeam() => fireBeam.Enable();
    public void EnableWaterBeam() => waterBeam.Enable();


}
