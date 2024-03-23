// Copyright takiido. All Rights Reserved.

using UnityEngine;

public class CNGN_Wheel : MonoBehaviour
{
    private Rigidbody _rb;

    public WheelType type;

    [Header("Suspension")]
    public float restLength;
    public float springTravel;
    public float springStiffness;
    public float damperStiffness;

    private float _minLength;
    private float _maxLength;
    private float _lastLength;
    private float _springLength;
    private float _springForce;
    private float _springVelocity;
    private float _damperForce;
    private Vector3 _suspensionForce;

    [Header("Wheel")]
    public float wheelRadius;
    public float steerAngle;
    public GameObject wheelModel;

    private void Start()
    {
        // Get the Rigidbody of the root object
        _rb = transform.root.GetComponent<Rigidbody>();

        // Calculate min and max suspension lengths
        _minLength = restLength - springTravel;
        _maxLength = restLength + springTravel;
    }

    private void Update()
    {
        // Rotate the wheel based on steer angle
        var localRotation = transform.localRotation;
        localRotation = Quaternion.Euler(localRotation.x, localRotation.y + steerAngle, localRotation.z);
        transform.localRotation = localRotation;
    }

    private void FixedUpdate()
    {
        // Perform a raycast to check for ground contact
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _maxLength + wheelRadius))
        {
            // Update suspension length and velocity
            _lastLength = _springLength;
            _springLength = hit.distance - wheelRadius;
            _springLength = Mathf.Clamp(_springLength, _minLength, _maxLength);
            _springVelocity = (_lastLength - _springLength) / Time.fixedDeltaTime;

            // Calculate spring and damper forces
            _springForce = springStiffness * (restLength - _springLength);
            _damperForce = damperStiffness * _springVelocity;

            // Calculate total suspension force
            _suspensionForce = (_springForce + _damperForce) * transform.up;

            var position = wheelModel.transform.position;
            position = new Vector3(position.x, (_springLength - _lastLength), position.z);
            wheelModel.transform.position = position;

            // Apply suspension force at contact point
            _rb.AddForceAtPosition(_suspensionForce, hit.point);
        }
    }
}
