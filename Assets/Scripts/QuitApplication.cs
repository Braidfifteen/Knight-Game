using UnityEngine;

public class QuitApplication : MonoBehaviour {

    private bool didQuit = false;
	
	void Update ()
    {
        if (didQuit)
            Application.Quit();	
	}

    public void Quit()
    {
        didQuit = true;
    }
}
