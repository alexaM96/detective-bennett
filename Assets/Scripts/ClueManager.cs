using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public void PickClue(Clue clue)
    {
        clue.isFound = true;
        Debug.Log("Wskazówka " + clue.name + " została znaleziona");

        PlayerPrefs.SetInt(clue.name, 1);

    }
}
