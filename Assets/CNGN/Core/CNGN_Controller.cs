// Copyright takiido. All Rights Reserved.

using UnityEngine;
using UnityEngine.InputSystem;

public class CNGN_Controller : MonoBehaviour
{
    public CNGN_Wheel[] wheels;

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
        // Calculate Ackermann angles for steering
        if (steerInput > 0) // Turning right
        {
            _ackAngleL = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            _ackAngleR = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        }
        else if (steerInput < 0) // Turning left
        {
            _ackAngleL = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            _ackAngleR = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        }
        else
        {
            _ackAngleL = 0.0f;
            _ackAngleR = 0.0f;
        }

        // Apply Ackermann angles to wheels
        foreach (CNGN_Wheel wheel in wheels)
        {
            switch (wheel.type)
            {
                case WheelType.FL:
                    wheel.steerAngle = _ackAngleL;
                    break;
                case WheelType.FR:
                    wheel.steerAngle = _ackAngleR;
                    break;
                default:
                    break;
            }
        }
    }

    // Method to handle steering input
    public void OnSteer(InputAction.CallbackContext context)
    {
        steerInput = context.ReadValue<float>();
    }
}