using UnityEngine;

public class DrumCollisionDetector : MonoBehaviour
{
    [SerializeField] private AudioClip drumSound;
    [SerializeField] private float minVelocityToPlay = 0.5f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Verifica si el objeto que colisiona es un palillo
        if (collision.gameObject.CompareTag("Drumstick"))
        {
            // Calcula la intensidad del golpe basada en la velocidad
            float collisionStrength = collision.relativeVelocity.magnitude;

            if (collisionStrength >= minVelocityToPlay)
            {
                // Reproduce el sonido con volumen proporcional a la fuerza
                audioSource.PlayOneShot(drumSound, Mathf.Clamp01(collisionStrength / 2f));
            }
        }
    }
}