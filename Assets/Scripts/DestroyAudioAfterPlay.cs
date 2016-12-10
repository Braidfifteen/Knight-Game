
using UnityEngine;

public class DestroyAudioAfterPlay : MonoBehaviour
{
    private AudioSource sound;

    private void OnEnable()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!sound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
