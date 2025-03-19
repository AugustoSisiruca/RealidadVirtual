using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable), typeof(Rigidbody), typeof(AudioSource))]
public class ShakeDetector : MonoBehaviour
{
    [Header("Configuración de Sonido")]
    [SerializeField] private AudioClip shakeSound;
    [SerializeField] private float shakeThreshold = 1.5f; // Velocidad mínima para activar el sonido
    [SerializeField] private float cooldownTime = 0.3f; // Tiempo entre sonidos

    private AudioSource audioSource;
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    private float lastShakeTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Configura el AudioSource
        audioSource.playOnAwake = false;
        audioSource.clip = shakeSound;

        // Suscribirse a eventos de agarre
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void Update()
    {
        if (grabInteractable.isSelected && IsShaking())
        {
            PlayShakeSound();
        }
    }

    private bool IsShaking()
    {
        // Verificar velocidad y cooldown
        if (rb.velocity.magnitude > shakeThreshold && Time.time > lastShakeTime + cooldownTime)
        {
            lastShakeTime = Time.time;
            return true;
        }
        return false;
    }

    private void PlayShakeSound()
    {
        // Variación de pitch para realismo
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.Play();
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Activar detección al agarrar
        enabled = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Desactivar detección al soltar
        enabled = false;
    }
}