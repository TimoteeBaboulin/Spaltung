using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TetardBaignoireUI : MonoBehaviour
{
    private RectTransform RectTransform;
    private bool Disappearing;
    private Vector3 StartingCoordinates;
    private Quaternion Rotation;

    public bool algue;
    public Item item;
    private float timer;

    private void Awake()
    {
        timer = 1;
        RectTransform = transform.parent.GetComponent<RectTransform>();
        Disappearing = false;
        StartingCoordinates = RectTransform.anchoredPosition;
        algue = false;
        transform.parent.GetComponent<Animator>().SetBool("Disappearing" , Disappearing);
    }

    private void OnEnable()
    {
        RectTransform.anchoredPosition = StartingCoordinates;
        GetComponent<Image>().enabled = true;
        Disappearing = false;
        timer = 1;
        transform.parent.GetComponent<Animator>().SetBool("Disappearing" , Disappearing);
    }

    private void Update()
    {
        if (Disappearing) {
            timer -= Time.deltaTime;
            if (timer <= 0)
                GetComponent<Image>().enabled = false;
        }
    }

    public void AttemptCatch()
    {
        if (!algue) {
            if (!Disappearing) {
                Disappearing = true;
                timer = 1;
                transform.parent.GetComponent<Animator>().SetBool("Disappearing" , Disappearing);
                
            }

            return;
        }
        Player.Instance.AddItem(item);
        Destroy(gameObject);
        
    }

    public void AlgueSet()
    {
        algue = true;
    }

    public void FaceAlgue()
    {
        RectTransform.LookAt(GetComponentInParent<Transform>());
    }
}
