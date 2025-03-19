using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoVelas : MonoBehaviour
{
    public int cont = 0;
    public GameObject[] velas = new GameObject[8];
    public int NumeroObjetivo = 10;

    void Start()
    {
        if (velas != null)
        {
            for (int i = 0; i < velas.Length; i++)
            {
                if (velas[i] != null)
                {
                    Transform flameTransform = velas[i].transform.Find("Flame");
                    if (flameTransform != null)
                    {
                        flameTransform.gameObject.SetActive(false); // Usa flameTransform.gameObject.SetActive(false)
                    }
                    else
                    {
                        Debug.LogError("No se encontró el objeto 'Flame' en la vela " + (i + 1));
                    }
                }
                else
                {
                    Debug.LogWarning("La vela en la posición " + i + " no ha sido asignada en el Inspector.");
                }
            }
        }
        else
        {
            Debug.LogError("El array de velas no ha sido inicializado. Asigna las velas en el Inspector.");
        }
    }
    
    void Update()
    {
        cont = 0; // Reinicia el contador en cada frame
        if (velas != null)
        {
            for (int i = 0; i < velas.Length; i++)
            {
                if (velas[i] != null)
                {
                    Transform flameTransform = velas[i].transform.Find("Flame");
                    if (flameTransform != null)
                    {
                        // Verifica si el objeto "Flame" está activo
                        if (flameTransform.gameObject.activeSelf)
                        {
                            cont += (int)Mathf.Pow(2, i);
                             
                        }
                    }
                    else
                    {
                        Debug.LogError("No se encontró el objeto 'Flame' en la vela " + (i + 1));
                    }
                }
                else
                {
                    Debug.LogWarning("La vela en la posición " + i + " no ha sido asignada en el Inspector.");
                }
            }
        }
    }
}
