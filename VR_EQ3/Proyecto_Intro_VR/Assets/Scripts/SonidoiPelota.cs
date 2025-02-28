using UnityEngine;
public class SonidoPelota : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;

    [SerializeField] private AudioClip bounceClip;
    [SerializeField, Range(0f, 1f)] private float maxVolume = 1f;
     [SerializeField] private float speedToMaxVolume = 10f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float speed = rb.velocity.magnitude;
        float volume = Mathf.Clamp(speed / speedToMaxVolume, 0f, maxVolume);
        if (volume > 0.05f)
        {
            audioSource.PlayOneShot(bounceClip, volume);
        }
    }
}
