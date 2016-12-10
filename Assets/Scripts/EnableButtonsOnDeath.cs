using UnityEngine;

public class EnableButtonsOnDeath : MonoBehaviour
{
    public GameObject[] buttons;

    private static bool isEnabled;

    void Start()
    {
        EnableButtonsOnDeath.isEnabled = false;
    }

    void Update()
    {
        if (EnableButtonsOnDeath.isEnabled)
        {
            foreach (GameObject button in buttons)
            {
                if (!button.activeInHierarchy)
                    button.SetActive(true);
            }
        }

        else
        {
            foreach (GameObject button in buttons)
            {
                if (button.activeInHierarchy)
                    button.SetActive(false);
            }
        }
    }

    public static void EnableButtons()
    {
        EnableButtonsOnDeath.isEnabled = true;
    }

    public static void DisableButtons()
    {
        EnableButtonsOnDeath.isEnabled = false;
    }
}
