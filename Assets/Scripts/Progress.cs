using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Dialogue dialogue;
    public List<Dialogue> dialogueList;
    public Button btn;
    public Button btnOld;

    private void Start()
    {
        btn.gameObject.SetActive(false);
        btnOld.gameObject.SetActive(true);
        btn.interactable = false;
        btnOld.interactable = true;
        dialogueList = new List<Dialogue>();
    }

    public void NextRoom()
    {
        if (PlayerPrefs.HasKey("Ciało") && PlayerPrefs.HasKey("Buty") && PlayerPrefs.HasKey("Nóż") && PlayerPrefs.HasKey("Papieros"))
        {
            dialogue.name = "Detektyw Bennett";
            dialogue.sentences.SetValue("Wygląda na to, że w tym miejscu to wszystko. Idę porozmawiać z sąsiadką.", 0);
            //dialogueList.Add(dialogue);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            btnOld.gameObject.SetActive(false);
            btnOld.interactable = false;
            btn.gameObject.SetActive(true);
            btn.interactable = true;
            btn.onClick.AddListener(goNext);
        }
        else
        {
            dialogue.name = "Detektyw Bennett";
            dialogue.sentences.SetValue("Chyba nie znalazłem jeszcze wszystkich śladów.", 0);
            //dialogueList.Add(dialogue);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        
    }
    public void goNext()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<LoadScene>().LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
