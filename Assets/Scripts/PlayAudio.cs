using UnityEngine;

public class PlayAudio : MonoBehaviour {

    public GameObject startSound;
    public GameObject clickSound;
    public GameObject quitSound;

    private bool startBeenClicked;
    private bool quitBeenClicked;

    public void PlayStartButtonSound()
    {
        if (!GameManager.IsMobile)
            startBeenClicked = true;
        GameObject sound = Instantiate(startSound, transform.position, transform.rotation) as GameObject;
    }

    public void PlayQuitButtonSound()
    {
        if (!GameManager.IsMobile)
            quitBeenClicked = true;
        GameObject sound = Instantiate(quitSound, transform.position, transform.rotation) as GameObject;
    }

    public void PlayStartHoverSound()
    {
        if (!GameManager.IsMobile)
        {
            if (!startBeenClicked)
            {
                GameObject sound = Instantiate(clickSound, transform.position, transform.rotation) as GameObject;
            }
        }
    }

    public void PlayQuitHoverSound()
    {
        if (!GameManager.IsMobile)
        {
            if (!quitBeenClicked)
            {
                GameObject sound = Instantiate(clickSound, transform.position, transform.rotation) as GameObject;
            }
        }
    }
}
