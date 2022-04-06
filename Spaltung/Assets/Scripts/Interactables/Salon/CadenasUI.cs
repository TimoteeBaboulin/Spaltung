using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenasUI : MonoBehaviour
{
    public List<int> code;
    public GameObject sortie;
    
    [SerializeField]
    private List<DigitUI> Digits;

    private void Awake()
    {
        foreach (var digit in GetComponentsInChildren<DigitUI>())
        {
            Digits.Add(digit);
        }
    }

    public void CheckCode()
    {
        for (int x = 0; x < Digits.Count; x++)
        {
            if (code[x] != Digits[x].GetDigit()) {
                Debug.Log("Mauvaise Combinaison.");
                return;
            }
        }

        sortie.GetComponent<Sortie>().open = true;
    }
}
