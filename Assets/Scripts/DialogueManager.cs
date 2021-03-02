using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogues;
    public Text nameT;
    public Text dialogueT;
    public Image portrait;

    public Sprite detective;
    public Sprite lady;
    public Sprite man1;
    public Sprite man2;

    public Animator animator;
    void Start()
    {
        dialogues = new Queue<string>();
    }

    //public void StartDialogue(Dialogue dialogue)
    //{
    //    animator.SetBool("IsOpen", true);

    //    nameT.text = dialogue.name;
    //    if (dialogue.name == "Pani Harris")
    //    {
    //        portrait.sprite = lady;
    //    }
    //    else if (dialogue.name == "Pan Roberts")
    //    {
    //        portrait.sprite = man2;
    //    }
    //    else if (dialogue.name == "Detektyw Bennett")
    //    {
    //        portrait.sprite = detective;
    //    }
    //    else
    //    {
    //        portrait.sprite = man1;
    //    }
    //    dialogues.Clear();

    //    foreach (string sentence in dialogue.sentences)
    //    {
    //        dialogues.Enqueue(sentence);
    //        //Debug.Log(dialogue.name + sentence);
    //    }

    //    DisplaySentence();

    //}
    public void StartDialogue(List<Dialogue> dialogueList)
    {
        animator.SetBool("IsOpen", true);

        foreach (Dialogue dialogue in dialogueList)
        {
            nameT.text = dialogue.name;

            if (dialogue.name == "Pani Harris")
            {
                portrait.sprite = lady;
            }
            else if (dialogue.name == "Pan Roberts")
            {
                portrait.sprite = man2;
            }
            else if (dialogue.name == "Detektyw Bennett")
            {
                portrait.sprite = detective;
            }
            else
            {
                portrait.sprite = man1;
            }
            //dialogues.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                dialogues.Enqueue(sentence);
                Debug.Log(dialogue.name + sentence);
            }

            DisplaySentence();
        }
    }

    public void DisplaySentence()
    {
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = dialogues.Dequeue();
        //Debug.Log(sentence);
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
        dialogueT.text = sentence;

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
