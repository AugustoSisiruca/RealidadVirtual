using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCHealth : MonoBehaviour
{
    public AudioClip hitSound;
    public string gloveTag = "guantes";
    public int maxHits = 3;
    public Animator npcAnimator;
    public GameObject keyObject; 
    private AudioSource audioSource;
    private int currentHits;
    private bool isDead = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (keyObject != null)
            keyObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag(gloveTag))
        {
            HandleHit(other);
        }
    }

    private void HandleHit(Collider glove)
    {
        // Play hit sound
        if (hitSound != null)
        {
            VelocityEstimator estimator = glove.GetComponent<VelocityEstimator>();
            if (estimator != null)
            {
                float velocity = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.Clamp01(velocity / 2f); // Ajusta este valor según necesites
                audioSource.PlayOneShot(hitSound, volume);
            }
            else
            {
                audioSource.PlayOneShot(hitSound);
            }
        }

        currentHits++;

        if (currentHits < maxHits)
        {
            // Trigger recoil animation
            npcAnimator.SetTrigger("Recoil");
        }
        else
        {
            // Trigger death sequence
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        npcAnimator.SetTrigger("Die");

        // Activate key
        if (keyObject != null)
            keyObject.SetActive(true);

        // Destroy NPC after delay

        // Disable collider
        GetComponent<Collider>().enabled = false;
    }
}