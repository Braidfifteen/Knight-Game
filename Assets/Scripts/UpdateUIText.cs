using UnityEngine;
using UnityEngine.UI;

public class UpdateUIText : MonoBehaviour
{
    public Text UIText;
    private string concactedText;

    public void UpdateText(string text)
    {
        UIText.text = text;
    }

    public void UpdateText(int text)
    {
        UIText.text = text.ToString();
    }

    public void UpdateText(string sText, int iText)
    {
        string concactedText = sText + iText.ToString();
        UIText.text = concactedText;
    }
}
