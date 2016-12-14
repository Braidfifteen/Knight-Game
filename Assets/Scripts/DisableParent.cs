using UnityEngine;

public class DisableParent : MonoBehaviour
{
    public GameObject parent;

    public void Disable()
    {
        parent.SetActive(false);
    }
}
