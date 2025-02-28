using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public GameObject Carnet;
    public GameObject PuertaC;
    public GameObject PuertaA;

    // Start is called before the first frame update
    void Start()
    {
        PuertaC.SetActive(true);
        PuertaA.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("El objeto seleccionado ha entrado en el trigger.");
        if (other.gameObject == Carnet)
        {
            PuertaA.SetActive(true);
            PuertaC.SetActive(false);
            Debug.Log("El objeto seleccionado ha entrado en el trigger.");
        }
        Debug.Log("El objeto seleccionado ha entrado en el trigger.");
    }
}
