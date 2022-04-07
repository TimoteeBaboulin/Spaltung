using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerUI : MonoBehaviour
{
    public static DialogueManagerUI current;

    public GameObject textMaster;
    
    public Text nameText;
    public Text dialogueText;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
    }

    public IEnumerator Say(string name, string dialogue)
    {
        Player.Instance.pause = true;
        if (!textMaster.activeSelf) textMaster.SetActive(true);
        nameText.text = name;
        dialogueText.text = dialogue;

        yield return null;
        
        while (!Input.GetButtonDown("Fire1"))
            yield return null;

        textMaster.SetActive(false);
        Player.Instance.pause = false;
    }
}
