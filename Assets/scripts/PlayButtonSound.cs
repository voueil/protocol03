using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clickSound;

    public void PlayClickSound()
    {
        if (source != null && clickSound != null)
        {
            source.PlayOneShot(clickSound);
        }
    }
}
