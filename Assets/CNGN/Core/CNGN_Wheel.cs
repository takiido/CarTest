// Copyright takiido. All Rights Reserved.

using UnityEngine;

public class CNGN_Wheel : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Suspension")] 
    public float restLength;
    public float springTravel;
    public float springStiffness;

    private float _minLength;
    private float _maxLength;
    private float _springLength;
    private float _springForce;

    private Vector3 _suspensionForce;

    [Header("Wheel")] 
    public float wheelRadius;
    
    private void Start()
    {
        _rb = transform.root.GetComponent<Rigidbody>();

        _minLength = restLength - springTravel;
        _maxLength = restLength + springTravel;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _maxLength + wheelRadius))
        {
            _springLength = hit.distance - wheelRadius;

            _springForce = springStiffness * (restLength - _springLength);
            _suspensionForce = _springForce * transform.up;
            
            _rb.AddForceAtPosition(_suspensionForce, hit.point);
        }
    }
}
