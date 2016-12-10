using UnityEngine.UI;
using UnityEngine;

public class EnableButtonHighlight : MonoBehaviour
{
    private Image highlight;
    private bool beenClicked;

    public Color highlightedColor;
    public Color clickedColor;

	void Start ()
    {
        highlight = GetComponent<Image>();
        highlight.enabled = false;
	}
	
    public void EnableClickedHighlight()
    {
        if (!GameManager.IsMobile)
            beenClicked = true;
        highlight.color = clickedColor;
        highlight.enabled = true;
    }

    public void EnableHighlight()
    {
        if (!GameManager.IsMobile)
        {
            if (!beenClicked)
            {
                highlight.color = highlightedColor;
                highlight.enabled = true;
            }
        }
    }

    public void DisableHighlight()
    {
        if (!GameManager.IsMobile)
        {
            if (!beenClicked)
                highlight.enabled = false;
        }
    }
}
