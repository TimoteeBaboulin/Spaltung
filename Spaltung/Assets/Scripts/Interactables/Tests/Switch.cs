using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, Iinteractable
{
    [SerializeField]
    private bool state;

    public GameObject doorName;
    private SwitchDoor door;
    public Vector3 position { get; set; }

    public void Interact(Player player)
    {
        state = !state;
        door.ChangeState();
        DialogueSystem.Instance.Say("Hi");
    }

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        door = doorName.GetComponent<SwitchDoor>();
    }
}
