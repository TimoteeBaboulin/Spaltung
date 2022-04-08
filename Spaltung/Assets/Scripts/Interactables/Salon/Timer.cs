using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject autrePorte;
    public AudioClip salonOST;
    public AudioClip gameOST;
    public AudioSource audioSource;
    public GameObject loseUI;

    private Level nextLevel;
    public float timer;
    private float TimerTime;

    private void Awake()
    {
        TimerTime = timer;
        nextLevel = autrePorte.GetComponentInParent<Level>(true);
    }

    public void OnEnable()
    {
        DialogueSystem.Instance.Say("Vite, l'Ours s'est réveillé et il arrive! \nLa porte est cadenassée, il faut trouver un code !", "Cerf");
        timer = TimerTime;
        audioSource.clip = salonOST;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            loseUI.SetActive(true);
            Player.Instance.StartPause();
            LevelManager.levelManager.ChangeLevel(nextLevel.name, autrePorte.transform.position);
            audioSource.clip = gameOST;
            audioSource.loop = true;
            audioSource.Play();
        }
            
    }
}
