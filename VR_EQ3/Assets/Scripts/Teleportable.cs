using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    [Header("TeleportParameters")]
    public float transformX;
    public float transformY;
    public float transformZ;

    [Range(0f, 360f)]
    public float rotationX;
    [Range(0f, 360f)]
    public float rotationY;
    [Range(0f, 360f)]
    public float rotationZ;
}
