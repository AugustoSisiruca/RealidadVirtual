using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLibro : MonoBehaviour
{
    public GameObject tapa;
    private HingeJoint hinge;
    void Start()
    {
        hinge = tapa.GetComponent<HingeJoint>();
        hinge.useMotor = false;
    }

    public void Abrir()
    {
        hinge.useMotor = true;
    }
}
