// Copyright takiido. All Rights Reserved.

using UnityEngine;

public class CNGN_Main : MonoBehaviour
{
    [Header("Wheels")]
    public GameObject frontLeft;
    public GameObject frontRight;
    public GameObject rearLeft;
    public GameObject rearRight;
    private GameObject[] _wheels;

    public float hp;
    private double _speed;

    private void Start()
    {
        AddWheels();
    }

    private void Accelerate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (GameObject wheel in _wheels)
            {
            }
        }
    }

    private void AddWheels()
    {
        _wheels[0] = frontLeft;
        _wheels[1] = frontRight;
        _wheels[2] = rearLeft;
        _wheels[3] = rearRight;
    }
}
