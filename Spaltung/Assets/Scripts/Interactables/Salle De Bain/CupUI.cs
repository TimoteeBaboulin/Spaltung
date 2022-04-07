using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CupUI : MonoBehaviour
{
    public Item key;
    public Sprite sprite;

    private bool cup;

    private void Awake()
    {
        cup = false;
    }

    public void ButtonClick()
    {
        Debug.Log("Click Detecte");
        if (Player.Instance.TakeItem(key))
        {
            cup = true;
            GetComponentInChildren<TetardUI>().CupSet();
            GetComponent<Animator>().enabled = false;
            GetComponent<Image>().sprite = sprite;
            GetComponent<Image>().color = Color.white;
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 160);
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 160);
        }
    }
}
