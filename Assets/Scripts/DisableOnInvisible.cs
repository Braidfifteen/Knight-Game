using UnityEngine;

public class DisableOnInvisible : MonoBehaviour {

    public void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}
