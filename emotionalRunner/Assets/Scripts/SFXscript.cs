using UnityEngine;

public class SFXscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public static SFXscript instance;

    public AudioSource audioSource;

    public AudioClip gemPickupClip;
    public AudioClip attackClip;
    public AudioClip hurtClip;
    public AudioClip deathClip;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
