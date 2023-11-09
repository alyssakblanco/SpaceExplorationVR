using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Orbits : MonoBehaviour
{
    public Transform sunTransform;
    public float orbitSpeed = 10.0f;
    public float rotationSpeed = 25.0f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private List<InputDevice> rightHandDevices = new List<InputDevice>();

    private void GetDevices()
    {
        rightHandDevices.Clear();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, rightHandDevices);
    }

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        GetDevices();
    }

    void Update()
    {
        transform.RotateAround(sunTransform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (rightHandDevices.Count == 0)
        {
            GetDevices();
        }

        foreach (var device in rightHandDevices)
        {
            bool buttonPressed;
            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out buttonPressed) && buttonPressed)
            {
                transform.position = initialPosition;
                transform.rotation = initialRotation;
            }
        }
    }
}
