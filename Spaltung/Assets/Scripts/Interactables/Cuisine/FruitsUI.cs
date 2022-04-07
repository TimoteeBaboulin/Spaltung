using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsUI : MonoBehaviour
{
    public bool libre;
    public GameObject fruitSuivant;

    public void Awake()
    {
    }

    public void AttemptTake()
    {
        if (libre)
        {
            if (fruitSuivant.GetComponent<FruitsUI>() != null) {
                fruitSuivant.GetComponent<FruitsUI>().libre = true;
            } else {
                fruitSuivant.GetComponent<GlandUI>().libre = true;
            }
            Destroy(gameObject);
            return;
        }
        DialogueSystem.Instance.Say("Je devrais prendre les fruits du dessus en premier.", "Alice");
    }
}
