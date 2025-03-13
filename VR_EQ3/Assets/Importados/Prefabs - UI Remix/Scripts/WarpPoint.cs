using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    private Vector3 location;
    private Quaternion rotation;
    void Start()
    {
        location = this.transform.position;
        rotation = this.transform.rotation;
    }

    public Vector3 retrieveLocation() { return location; }
    public Quaternion retrieveRotation() { return rotation; }
    public void updateTransform(Vector3 newLocation, Quaternion newRotation)
    {
        location = newLocation;
        rotation = newRotation;
    }
}
