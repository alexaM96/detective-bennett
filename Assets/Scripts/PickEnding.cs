using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickEnding : MonoBehaviour
{
    public void GoodEnding()
    {
        PlayerPrefs.SetString("Koniec", "good");
        FindObjectOfType<LoadScene>().LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BadEnding()
    {
        PlayerPrefs.SetString("Koniec", "bad");
        FindObjectOfType<LoadScene>().LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
