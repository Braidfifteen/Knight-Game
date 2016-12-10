using UnityEngine;

public class DisableOnPlayerDead : MonoBehaviour
{
    void Update()
    {
        if (PlayerManager.SharedInstance.IsDead)
            gameObject.SetActive(false);
    }
}
