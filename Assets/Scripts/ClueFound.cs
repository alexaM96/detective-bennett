using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueFound : MonoBehaviour
{
    public Clue clue;

    public void FindClue()
    {
        FindObjectOfType<ClueManager>().PickClue(clue);
    }
}
