using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    IEnumerator<DialogueEntry> currentSentenceNumerator;
    public Text nameT;
    public Text dialogueT;
    public Image portrait;

    public Sprite detective;
    public Sprite lady;
    public Sprite man1;
    public Sprite man2;

    public Animator animator;
    
    class DialogueEntry
    {
        public string displayName;
        public Sprite displayedPortrait;
        public string displayText;
    }
    public void StartDialogue(List<Dialogue> dialogueList)
    {
        Debug.Log($"Startdialogue with { dialogueList.Count} items");
        animator.SetBool("IsOpen", true);
        var dialogueEntryList = new List<DialogueEntry>();

        foreach (Dialogue dialogue in dialogueList)
        {
            foreach (string sentence in dialogue.sentences)
            {
                DialogueEntry dialogueEntry = new DialogueEntry();
                dialogueEntry.displayName = dialogue.name;
                dialogueEntry.displayText = sentence;

                if (dialogue.name == "Pani Harris")
                {
                    dialogueEntry.displayedPortrait = lady;
                }
                else if (dialogue.name == "Pan Roberts")
                {
                    dialogueEntry.displayedPortrait = man2;
                }
                else if (dialogue.name == "Detektyw Bennett")
                {
                    dialogueEntry.displayedPortrait = detective;
                }
                else
                {
                    dialogueEntry.displayedPortrait = man1;
                }
                dialogueEntryList.Add(dialogueEntry);
            }
        }
        currentSentenceNumerator = dialogueEntryList.GetEnumerator();
        DisplayNextSentence();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        var list = new List<Dialogue>();
        list.Add(dialogue);
        StartDialogue(list);
    }


    public void DisplayNextSentence()
    {
        Debug.LogError("Displaying next dialog");
        bool isValid = currentSentenceNumerator.MoveNext();
        if (!isValid)
        {
            EndDialogue();
            return;
        }

        var sentence = currentSentenceNumerator.Current;
        //Debug.Log(sentence);
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
        dialogueT.text = sentence.displayText;
        portrait.sprite = sentence.displayedPortrait;
        nameT.text = sentence.displayName;

    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueT.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueT.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
