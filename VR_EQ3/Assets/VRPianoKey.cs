using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(HingeJoint), typeof(XRGrabInteractable))]
public class VRPianoKey : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip keySound;
    [Range(0, 1)] public float maxVolume = 1f;
    [Range(0, 1)] public float pitchRandomness = 0.05f;
    
    [Header("Key Physics")]
    [Range(0, 45)] public float pressAngleThreshold = 10f;
    public float returnSpringForce = 100f;
    public float damper = 5f;

    private AudioSource audioSource;
    private Rigidbody rb;
    private HingeJoint hinge;
    private XRGrabInteractable grabInteractable;
    
    private float initialAngle;
    private bool isPressed;
    private float originalPitch;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        ConfigureHingeJoint();
        SetupAudioSource();
        ConfigureGrabInteractable();
    }

    void ConfigureHingeJoint()
    {
        hinge.useSpring = true;
        JointSpring spring = new JointSpring
        {
            spring = returnSpringForce,
            damper = damper
        };
        hinge.spring = spring;
    }

    void SetupAudioSource()
    {
        audioSource.clip = keySound;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // 3D spatial audio
        originalPitch = audioSource.pitch;
    }

    void ConfigureGrabInteractable()
    {
        grabInteractable.throwOnDetach = false;
        grabInteractable.movementType = XRBaseInteractable.MovementType.Instantaneous;
        grabInteractable.retainTransformParent = true;
    }

    void Update()
    {
        CheckKeyPressState();
    }

    void CheckKeyPressState()
    {
        float currentAngle = hinge.angle;
        
        if (!isPressed && currentAngle >= pressAngleThreshold)
        {
            OnKeyPressed();
        }
        else if (isPressed && currentAngle < pressAngleThreshold * 0.5f)
        {
            OnKeyReleased();
        }
    }

    void OnKeyPressed()
    {
        isPressed = true;
        PlayKeySound();
    }

    void OnKeyReleased()
    {
        isPressed = false;
        StartCoroutine(FadeOutSound());
    }

    void PlayKeySound()
    {
        if (!audioSource.isPlaying)
        {
            // Aleatoriedad de tono para mayor realismo
            audioSource.pitch = originalPitch + Random.Range(-pitchRandomness, pitchRandomness);
            audioSource.volume = maxVolume;
            audioSource.Play();
        }
    }

    IEnumerator FadeOutSound()
    {
        float fadeTime = 0.1f;
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        
        audioSource.Stop();
        audioSource.volume = maxVolume;
    }

    // Para permitir la interacción con controladores VR
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("VRController"))
        {
            rb.AddForceAtPosition(collision.impulse * 0.1f, collision.contacts[0].point, 
                ForceMode.Impulse);
        }
    }
}