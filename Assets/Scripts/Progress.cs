using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Dialogue dialogue;
    public Button btn;
    public Button btnOld;
    string detektyw = "Detektyw Bennett";

    private void Start()
    {
        btn.gameObject.SetActive(false);
        btnOld.gameObject.SetActive(true);
        btn.interactable = false;
        btnOld.interactable = true;
    }

    public void NextRoom()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (PlayerPrefs.HasKey("Ciało") && PlayerPrefs.HasKey("Buty") && PlayerPrefs.HasKey("Nóż") && PlayerPrefs.HasKey("Papieros"))
            {
                dialogue.name = detektyw;
                dialogue.sentences.SetValue("Wygląda na to, że w tym miejscu to wszystko. Idę porozmawiać z sąsiadką.", 0);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                btnOld.gameObject.SetActive(false);
                btnOld.interactable = false;
                btn.gameObject.SetActive(true);
                btn.interactable = true;
                btn.onClick.AddListener(goNext);
            }
            else
            {
                dialogue.name = detektyw;
                dialogue.sentences.SetValue("Chyba nie znalazłem jeszcze wszystkich śladów.", 0);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (PlayerPrefs.HasKey("Sąsiadka") && PlayerPrefs.HasKey("Mężczyzna1"))
            {
                dialogue.name = detektyw;
                dialogue.sentences.SetValue("Świadkowie przesłuchani, czas wracać do biura.", 0);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                btnOld.gameObject.SetActive(false);
                btnOld.interactable = false;
                btn.gameObject.SetActive(true);
                btn.interactable = true;
                btn.onClick.AddListener(goNext);
            }
            else
            {
                dialogue.name = detektyw;
                dialogue.sentences.SetValue("Nie mogę jeszcze wracać do biura, nie przesłuchałem wszystkich świadków.", 0);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (PlayerPrefs.HasKey("Mężczyzna2") && PlayerPrefs.HasKey("Podsumowanie"))
            {
                dialogue.name = detektyw;
                dialogue.sentences.SetValue("Chyba już wiem kto zamordował Panią Smith.", 0);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                btnOld.gameObject.SetActive(false);
                btnOld.interactable = false;
                btn.gameObject.SetActive(true);
                btn.interactable = true;
                btn.onClick.AddListener(goNext);
            }
            else
            {
                dialogue.name = detektyw;
                dialogue.sentences.SetValue("Zanim wybiorę mordercę, muszę podsumować co znalazłem.", 0);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }
    public void goNext()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<LoadScene>().LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
