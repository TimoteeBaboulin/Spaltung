using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitUI : MonoBehaviour
{
    public List<Sprite> numbers;
    
    private int Digit;
    private Image Image;

    private void Awake()
    {
        Digit = 1;
        Image = GetComponent<Image>();
    }

    public void ArrowUp()
    {
        Digit++;
        if (Digit == 10)
            Digit = 1;
        Image.sprite = numbers[Digit - 1];
    }

    public void ArrowDown()
    {
        Digit--;
        if (Digit == 0)
            Digit = 9;
        Image.sprite = numbers[Digit - 1];
    }

    public int GetDigit()
    {
        return Digit;
    }
}
