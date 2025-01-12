using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found.");
        }
        else
        {
            audioSource.Play(); // Start playing music
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume; // Set the volume (0 to 1 range)
        }
    }
}
