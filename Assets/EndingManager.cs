using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    public Text text;
    public Button continueButton;
    IEnumerator<string> currentSentenceNumerator;

    [TextArea(1, 10)]
    public string[] badEnding;

    [TextArea(1, 10)]
    public string[] goodEnding;
    void Start()
    {
        if (PlayerPrefs.GetString("Koniec", "bad") == "good")
        {
            StartDialogue(goodEnding);
        }
        else if (PlayerPrefs.GetString("Koniec", "bad") == "bad")
        {
            StartDialogue(badEnding);
        }
    }

    private IEnumerable<string> BuildList (string[] array)
    {
        foreach (var text in array)
        {
            string dialogue = text;
            
            yield return dialogue;
        }
        
    }

    public void StartDialogue(string[] array)
    {
        var textList = BuildList(array);
        currentSentenceNumerator = textList.GetEnumerator();
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        bool isValid = currentSentenceNumerator.MoveNext();
        if (!isValid)
        {
            EndDialogue();
            return;
        }

        var sentence = currentSentenceNumerator.Current;
        text.text = sentence;

    }

    public void EndDialogue()
    {
        PlayerPrefs.SetInt("ended", 1);
        FindObjectOfType<LoadScene>().LoadNextScene(0);
    }
}
