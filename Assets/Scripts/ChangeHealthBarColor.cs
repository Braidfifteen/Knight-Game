using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthBarColor : MonoBehaviour {

    public Slider healthBar;
    public Image healthBarFill;
    public Color MaxHealthColor = Color.green;
    public Color MidHealthColor = Color.yellow;
    public Color MinHealthColor = Color.red;

    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        if (healthBar.value > 50)
            healthBarFill.color = MaxHealthColor;
        else if (healthBar.value > 25)
            healthBarFill.color = MidHealthColor;
        else if (healthBar.value > 0)
            healthBarFill.color = MinHealthColor;
        else
            healthBarFill.color = Color.clear;
    }
}
