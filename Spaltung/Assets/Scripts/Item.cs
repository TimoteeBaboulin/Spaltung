using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
}
