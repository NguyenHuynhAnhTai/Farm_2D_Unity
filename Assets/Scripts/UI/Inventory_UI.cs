using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Collectable;

public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggelInventory();
        }
    }

    public void ToggelInventory()
    {
        if (!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
            SetUp();
        }
        else
        {
            InventoryPanel.SetActive(false);
        }
    }

    void SetUp()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectibleType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
