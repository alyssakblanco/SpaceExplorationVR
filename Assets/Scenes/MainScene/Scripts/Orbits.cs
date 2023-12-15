using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Orbits : MonoBehaviour
{
    public Transform sunTransform;
    public Transform mainCameraTransform;
    public float orbitSpeed;
    public float rotationSpeed;
    private Vector3 planetInitialPosition;
    private Quaternion planetInitialRotation;
    private Vector3 rigInitialPosition;
    private Quaternion rigInitialRotation;
    private List<InputDevice> rightHandDevices = new List<InputDevice>();
    private float speedScaledBy = 10;

    private void GetDevices()
    {
        rightHandDevices.Clear();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, rightHandDevices);
    }

    void Start()
    {
        planetInitialPosition = transform.position;
        planetInitialRotation = transform.rotation;

        Transform xrRig = mainCameraTransform.parent;
        if (xrRig != null)
        {
            rigInitialPosition = xrRig.position;
            rigInitialRotation = xrRig.rotation;
        }
        else
        {
            rigInitialPosition = mainCameraTransform.position;
            rigInitialRotation = mainCameraTransform.rotation;
        }

        GetDevices();
    }

    void Update()
    {
        transform.RotateAround(sunTransform.position, Vector3.up, (orbitSpeed / speedScaledBy) * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (rightHandDevices.Count == 0)
        {
            GetDevices();
        }

        foreach (var device in rightHandDevices)
        {
            bool bButtonPressed;
            bool aButtonPressed;

            device.TryGetFeatureValue(CommonUsages.secondaryButton, out bButtonPressed);
            device.TryGetFeatureValue(CommonUsages.primaryButton, out aButtonPressed);

            if (bButtonPressed)
            {
                transform.position = planetInitialPosition;
                transform.rotation = planetInitialRotation;
            }

            if (aButtonPressed)
            {
                Transform xrRig = mainCameraTransform.parent;
                if (xrRig != null)
                {
                    xrRig.position = rigInitialPosition;
                    xrRig.rotation = rigInitialRotation;
                }
                else
                {
                    mainCameraTransform.position = rigInitialPosition;
                    mainCameraTransform.rotation = rigInitialRotation;
                }
            }
        }
    }
}
