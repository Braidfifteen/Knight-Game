using UnityEngine;

public class TESTDISABLEANIMATION : MonoBehaviour
{
    public GameObject parent;
    public void Disable()
    {
        parent.SetActive(false);
    }

    //public void parentDisable()
    //{

    //}
}
