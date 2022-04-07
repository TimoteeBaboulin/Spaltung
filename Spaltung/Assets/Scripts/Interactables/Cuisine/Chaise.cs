using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaise : MonoBehaviour, Iinteractable
{
    private bool state;
    public GameObject unlockGO;
    private Gland unlock;

    public GameObject cerealeGO;
    private PaquetCereale cereale;
    
    private void Awake()
    {
        unlock = unlockGO.GetComponent<Gland>();
        cereale = cerealeGO.GetComponent<PaquetCereale>();
        position = transform.position;
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 position { get; set; }
    public void Interact(Player player)
    {
        if (!state) {
            state = true;
            DialogueSystem.Instance.Say("Cette chaise est lourde a pousser.", "Alice");
            transform.localPosition = new Vector3(2,0.1f, 1.4f);
            unlock.state = true;
            cereale.chaise = true;
            position = transform.position;
            return;
        }
        DialogueSystem.Instance.Say("Maintenant je peut atteindre en hauteur.", "Alice");
    }
}
