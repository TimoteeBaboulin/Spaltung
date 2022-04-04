using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventoryUI : MonoBehaviour
{
    private Player player;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Player.OnInventoryUpdate += UpdateInventory;
    }

    void UpdateInventory()
    {
        foreach (var child in GetComponentsInChildren<Transform>())
        {
            if (child != transform)
                Destroy(child.gameObject);
        }

        foreach (var item in player.inventory)
        {
            GameObject newChild = Instantiate(prefab, transform);
            newChild.GetComponent<Image>().sprite = item.sprite;
        }
    }
}
