using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager SharedInstance = null;
    private bool isDead = false;

    public bool IsDead { get { return isDead; } }
    
    void Awake()
    {
        if (SharedInstance == null)
            SharedInstance = this;
        else if (SharedInstance != this)
            Destroy(gameObject);
        if (SharedInstance.IsDead)
            isDead = false;
    }

    public void PlayerDied()
    {
        isDead = true;
    }
}
