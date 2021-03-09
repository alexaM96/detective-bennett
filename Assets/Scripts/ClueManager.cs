using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public InventorySlot[] slots;
    public void PickClue(Clue clue)
    {
        clue.isFound = true;
        Debug.Log("Wskazówka " + clue.name + " została znaleziona");

        PlayerPrefs.SetInt(clue.name, 1);

        foreach (var slot in slots)
        {
            if(slot.name == clue.name)
            {
                slot.image.SetActive(true);
            }
        }
    }
}
