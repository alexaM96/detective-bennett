using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public LoadScene loadScene;
    public Button continueB;

    public void Start()
    {
        if (PlayerPrefs.HasKey("started") && !PlayerPrefs.HasKey("ended"))
        {
            continueB.interactable = true;
        }
    }

    public void StartNewGame()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            float volume = PlayerPrefs.GetFloat("volume");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetFloat("volume", volume);
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
        PlayerPrefs.SetInt("started", 1);
        loadScene.LoadNextScene(2);
    }

    public void ContinueGame()
    {
        loadScene.LoadNextScene(PlayerPrefs.GetInt("scene"));
    }
}
