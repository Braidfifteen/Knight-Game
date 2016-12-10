using UnityEngine;

public class DisableAudioAfterPlay : MonoBehaviour {

    private AudioSource sound;

    private void OnEnable()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!sound.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
