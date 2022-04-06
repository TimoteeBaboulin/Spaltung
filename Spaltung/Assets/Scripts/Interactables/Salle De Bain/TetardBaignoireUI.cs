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

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        Disappearing = false;
        StartingCoordinates = RectTransform.anchoredPosition;
        algue = false;
    }

    private void OnEnable()
    {
        RectTransform.anchoredPosition = StartingCoordinates;
        GetComponent<Image>().enabled = true;
        Disappearing = false;
    }

    private void Update()
    {
        if (Disappearing && Vector3.Distance(StartingCoordinates, RectTransform.anchoredPosition) < 250)
        {
            Quaternion newRotation = Quaternion.Euler(0,0,45);
            RectTransform.Translate(newRotation * RectTransform.right * Time.deltaTime * 150);
        }

        if (Vector3.Distance(StartingCoordinates, RectTransform.anchoredPosition) >= 250)
        {
            GetComponent<Image>().enabled = false;
        }
    }

    public void AttemptCatch()
    {
        if (!algue) {
            if (!Disappearing) {
                Disappearing = true;
                Rotation = Quaternion.Euler(new Vector3(0,0,Random.Range(0,359)));
                RectTransform.localRotation = Rotation;
                return;
            }

            return;
        }
        Player.current.AddItem(item);
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
