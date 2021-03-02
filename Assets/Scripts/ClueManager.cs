using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ClueManager : MonoBehaviour
{

    public void PickClue(Clue clue)
    {
        clue.isFound = true;
        Debug.Log("Wskazówka " + clue.name + " została znaleziona");
        Thread.Sleep(10000);
        Debug.Log("after sleep");

        PlayerPrefs.SetInt(clue.name, 1);

    }
}
