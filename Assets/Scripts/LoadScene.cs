using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Animator fade;
    public float fadeTime = 1f;

    public void LoadNextScene(int index)
    {
        StartCoroutine(LoadByIndex(index));
    }
    IEnumerator LoadByIndex(int index)
    {
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(index);

    }
}
