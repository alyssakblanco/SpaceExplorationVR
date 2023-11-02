using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour
{
    public Transform sunTransform;
    public float orbitSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sunTransform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
