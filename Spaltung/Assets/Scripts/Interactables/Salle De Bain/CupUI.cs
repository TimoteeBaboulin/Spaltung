using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupUI : MonoBehaviour
{
    public Item key;

    private bool cup;

    private void Awake()
    {
        cup = false;
    }

    public void ButtonClick()
    {
        Debug.Log("Click Detecte");
        if (Player.current.TakeItem(key))
        {
            cup = true;
            GetComponentInChildren<TetardUI>().CupSet();
            GetComponent<Animator>().enabled = false;
            GetComponent<Image>().sprite = key.sprite;
        }
    }
}
