// Copyright takiido. All Rights Reserved.

using UnityEngine;

public class CNGN_Wheel : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Suspension")] 
    public float restLength;
    public float springTravel;

    private float _minLength;
    private float _maxLength;
    private float _springLength;

    [Header("Wheel")] 
    public float wheelRadius;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _minLength = restLength - springTravel;
        _maxLength = restLength + springTravel;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _maxLength + wheelRadius))
        {
            _springLength = hit.distance - wheelRadius;
        }
    }
}
