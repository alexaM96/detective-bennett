using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject image;
    public new string name;
    void Start()
    {
        if (PlayerPrefs.HasKey(name))
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
    }
}
