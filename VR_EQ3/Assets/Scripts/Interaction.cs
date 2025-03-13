using System.Collections;
using UnityEngine;
using TMPro;

interface IInteractable
{
    public void Interact();
}

public class Interaction : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public TextMeshProUGUI interactText; // Referencia al texto de interacción

    private bool isInRange = false;
    private Coroutine blinkCoroutine;
    private bool isReadingNote = false;

    void Start()
    {
        // Asegúrate de que el texto esté oculto al inicio
        SetTextAlpha(0); // Configura el texto con transparencia total
    }

    void Update()
    {
        // Crear un rayo desde la posición del jugador hacia adelante
        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);

        // Detectar si hay algún objeto dentro del rango de interacción
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                // Si el jugador está en rango y no está leyendo la nota, inicia la corutina de parpadeo
                if (!isInRange && !isReadingNote)
                {
                    isInRange = true;
                    blinkCoroutine = StartCoroutine(BlinkText());
                }

                // Detectar la tecla "E" para interactuar
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                    isReadingNote = true; // El usuario está leyendo la nota
                    StopBlinking(); // Detener el parpadeo y ocultar el texto
                }
            }
        }
        else
        {
            // Si el jugador sale del rango, detener el parpadeo y ocultar el texto
            StopBlinking();
        }

        // Si el usuario cierra la nota, reactivar el parpadeo si está en rango
        if (isReadingNote && Input.GetKeyDown(KeyCode.Escape))
        {
            isReadingNote = false;
            if (isInRange)
            {
                blinkCoroutine = StartCoroutine(BlinkText());
            }
        }
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // Cambiar entre alta y baja intensidad en el alfa para crear el efecto de parpadeo
            for (float alpha = 1f; alpha >= 0.3f; alpha -= 0.1f)
            {
                SetTextAlpha(alpha);
                yield return new WaitForSeconds(0.1f); // Velocidad de cambio de intensidad (más lento)
            }
            for (float alpha = 0.3f; alpha <= 1f; alpha += 0.1f)
            {
                SetTextAlpha(alpha);
                yield return new WaitForSeconds(0.1f); // Velocidad de cambio de intensidad
            }
        }
    }

    private void SetTextAlpha(float alpha)
    {
        Color color = interactText.color;
        color.a = alpha;
        interactText.color = color;
    }

    private void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }
        SetTextAlpha(0); // Asegurarse de que el texto esté completamente oculto
        isInRange = false;
    }
}





