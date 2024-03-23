// Copyright takiido. All Rights Reserved.

using UnityEngine;
using UnityEngine.InputSystem;

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

    public void OnSteer(InputAction.CallbackContext context)
    {
        steerInput = context.ReadValue<float>();
    }
}
