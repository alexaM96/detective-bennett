using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer mixer;
    public Slider volumeSlider;
    public GameObject popupUI;
    public Button backButton;
    public Button quitButton;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.75f);
        pauseMenuUI.SetActive(false);
        popupUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void BackToMenu()
    {
        popupUI.SetActive(true);
        backButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(false);
    }

    public void BackToMenuOk()
    {
        popupUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float value)
    {
        mixer.SetFloat("volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("volume", value);
    }

    public void QuitGame()
    {
        popupUI.SetActive(true);
        backButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
    }

    public void QuitGameOk()
    {
        popupUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
    }

    public void BackToPause()
    {
        popupUI.SetActive(false);
    }
}
