using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReveilAlice : MonoBehaviour
{
    private void OnEnable()
    {
        DialogueSystem.Instance.Say("Maman? Ou es-tu?", "Aldjia");
        Destroy(gameObject);
    }
}
