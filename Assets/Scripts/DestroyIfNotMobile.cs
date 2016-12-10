using UnityEngine;

public class DestroyIfNotMobile : MonoBehaviour
{
	void Start ()
    {
        if (!GameManager.IsMobile)
            Destroy(gameObject);		
	}
}
