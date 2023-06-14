public class Item {
    public string itemName; // Name of the item
    public Action associatedAction; // Action associated with the item

    public Item(string name, Action action) {
        itemName = name;
        associatedAction = action;
    }
}
