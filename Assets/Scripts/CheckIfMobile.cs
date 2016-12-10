using UnityEngine;

public class CheckIfMobile : MonoBehaviour {

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            GameManager.IsMobile = true;

        }
        else
            GameManager.IsMobile = false;
    }
}
