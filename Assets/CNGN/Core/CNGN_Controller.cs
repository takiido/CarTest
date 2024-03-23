// Copyright takiido. All Rights Reserved.

using UnityEngine;

public class CNGN_Controller : MonoBehaviour
{
    public CNGN_Wheel[] frontWheels;
    
    [Header("Car specs")] 
    public float wheelBase;
    public float rearTrack;
    public float turnRadius;
    
    [Header("Input")]
    public float steerInput;

    private float _ackAngleL;
    private float _ackAngleR;

    private void Update()
    {
        steerInput = Input.GetAxis("Horizontal");
        
        if (steerInput > 0) // Turning right
        {
            
        }
        else if (steerInput < 0) // Turning left
        {

        }
        else 
        {
            
        }
    }

    public void OnSteer()
    {
        
    }
}
