using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> itemList = new List<Item>();
    public List<Item> usableItemList = new List<Item>(); // Items that can be used

    public Player player; // Reference to the player

    private void Start() {
        // Sort items and populate the usable item list
        SortItems();
    }

    private void SortItems() {
        // Sort items and populate the usable item list
        usableItemList.Clear();
        itemList.Sort((a, b) => a.itemName.CompareTo(b.itemName));

        int maxUsableItems = Mathf.Min(3, itemList.Count);
        usableItemList.AddRange(itemList.GetRange(0, maxUsableItems));

        // Sort the player's inventory
        player.SortInventory();
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        SortItems();
    }

    public void RemoveItem(Item item) {
        itemList.Remove(item);
        SortItems();
    }

    public void AssociateAction(Item item, Action action) {
        item.associatedAction = action;
    }
}
