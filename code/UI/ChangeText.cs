using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text displayText; //The text we modify
    public bool defaultText; //Which state the text is in
    public string initial; //First text
    public string final; //Second text

    public void SetText(string _text) //Set the text to something specific
    {
        displayText.text = _text;
    }
    public void SetState(bool _state) //Set the defaultText bool value
    {
        defaultText = _state;
    }
    public void RefreshText() //Changes the text depending on the defaultText bool
    {
        if (defaultText)
            displayText.text = initial;
        else
            displayText.text = final;
    }
    public void FlipState() //Flips the bool value and refreshes the text
    {
        defaultText = !defaultText;
        RefreshText();
    }
}
