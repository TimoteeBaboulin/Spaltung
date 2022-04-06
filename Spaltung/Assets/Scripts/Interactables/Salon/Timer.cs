using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject autrePorte;

    private Level nextLevel;
    [SerializeField]
    private float timer;

    private void Awake()
    {
        nextLevel = autrePorte.GetComponentInParent<Level>();
        timer = 2;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            LevelManager.levelManager.ChangeLevel(nextLevel.name, autrePorte.transform.position);
        }
            
    }
}
