using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgueUI : MonoBehaviour
{
    public Item key;
    public Sprite algue;

    public void SetAlgue()
    {
        if (Player.Instance.TakeItem(key))
        {
            GetComponent<Image>().sprite = algue;
            GetComponent<Image>().color = Color.white;
            TetardBaignoireUI tetard = GetComponentInChildren<TetardBaignoireUI>();
            tetard.FaceAlgue();
            tetard.AlgueSet();
            DialogueSystem.Instance.Say("L'algue semble calmer le tetard.", "Aldjia");
        }
    }
}
