using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarReticula : MonoBehaviour
{
    public float rotationSpeed = 50f; 

    public void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}


