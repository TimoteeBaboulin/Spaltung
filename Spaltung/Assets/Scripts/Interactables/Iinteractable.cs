using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface Iinteractable
{
    Vector3 position { get; set; }
    void Interact(Player player);
}

