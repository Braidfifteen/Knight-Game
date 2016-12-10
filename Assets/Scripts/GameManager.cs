using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private static bool isMobile;

    public static bool IsMobile { get { return isMobile; } set { isMobile = value; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
