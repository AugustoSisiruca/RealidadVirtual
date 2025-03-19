using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    // Variables publicas para el inspector
    public Transform[] pisos; // Array para almacenar los puntos de destino del ascensor
    public float velocidad = 2f; // Velocidad del ascensor
    public float distanciaMinima = 0.1f; // Distancia minima para considerar que se ha llegado al destino
    public GameObject puertas; // GameObject de las puertas del ascensor
    public float tiempoRetrasoPuertas = 2f; // Tiempo de retraso para la animacion de las puertas

    private int pisoActual = 0; // Indice del piso actual
    private Vector3 destino; // Posicion de destino
    private bool enMovimiento = false; // Indica si el ascensor esta en movimiento
    private Animator puertasAnimator; // Animator de las puertas

    void Start()
    {
        if (puertas != null)
        {
            puertasAnimator = puertas.GetComponent<Animator>();
        }
        else
        {
            Debug.LogWarning("El GameObject de las puertas no esta asignado.");
        }

        if (pisos == null || pisos.Length == 0)
        {
            Debug.LogError("El array de pisos no esta asignado o esta vacio.");
        }
    }

    void Update()
    {
        if (enMovimiento)
        {
            MoverAscensor();
        }
    }

    private void MoverAscensor()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < distanciaMinima)
        {
            enMovimiento = false;
            if (puertasAnimator != null)
            {
                puertasAnimator.SetBool("movimiento", false); // Abre las puertas
            }
        }
    }

    public void IrAlPiso(int indicePiso)
    {
        if (pisos != null && indicePiso >= 0 && indicePiso < pisos.Length)
        {
            destino = pisos[indicePiso].position;
            pisoActual = indicePiso;
            StartCoroutine(IniciarMovimiento()); // Inicia el proceso de cierre de puertas y movimiento
        }
        else
        {
            Debug.LogError("Indice de piso invalido o array de pisos no asignado.");
        }
    }

    public void MoverAscensorDireccion(bool subir)
    {
        if (subir && pisoActual < pisos.Length - 1) // Subir
        {
            IrAlPiso(pisoActual + 1);
        }
        else if (!subir && pisoActual > 0) // Bajar
        {
            IrAlPiso(pisoActual - 1);
        }
        else
        {
            Debug.LogWarning("Movimiento invalido. Ya estas en el piso mas alto o mas bajo.");
        }
    }

    private IEnumerator IniciarMovimiento()
    {
        if (puertasAnimator != null)
        {
            puertasAnimator.SetBool("movimiento", true); // Cierra las puertas
        }

        yield return new WaitForSeconds(tiempoRetrasoPuertas); // Espera a que la animacion de cierre termine

        enMovimiento = true; // Inicia el movimiento del ascensor
    }
}
