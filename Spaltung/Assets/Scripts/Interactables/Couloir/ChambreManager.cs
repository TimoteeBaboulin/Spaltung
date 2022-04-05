using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChambreManager : MonoBehaviour
{
    public bool grenouille, ecureuil;

    public GameObject porte;
    public GameObject chambre2;

    private void Awake()
    {
        grenouille = false;
        ecureuil = false;
    }

    private void OnEnable()
    {
        if (!ecureuil || !grenouille)
            return;
        porte.GetComponent<Door>().autrePorte = chambre2;
        porte.GetComponent<Door>().UpdateDoor();
        DialogueSystem.instance.Say("Il y a du bruit venant de ma chambre.", "Alice");
        Destroy(gameObject);
    }
}
