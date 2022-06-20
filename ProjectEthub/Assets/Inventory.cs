using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> items = new List<Item>();
    public List<Item> displayedInventory = new List<Item>(); //allows for items to be moved around in the inventory
    public List<int> count = new List<int>();
    public int maxSpacePerItem;
    public int maxInventorySpace;
    #region Singleton
    public static Inventory instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one Inventory big man");
            return;
        }
        instance = this;
        maxSpacePerItem = 99;
        maxInventorySpace = 30;
    }
    #endregion

    public delegate void OnItemChanged(); //creates the event where theres an item change
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item) { //returns true if item is able to be picked up and also adds to inventory if so. returns false otherwise.
        if (items.Count >= maxInventorySpace) { //if a new item is picked up and the inventory is full and there is no space return false;
            if (!items.Contains(item)) {
                Debug.Log("max space (new item error)");
                return false;
            }
        }
        if (item.isStackable) {
            bool needsNewSlot = true;
            for (int i = 0; i < items.Count; i++) { //looks for a slot to stack an item onto
                if (items[i] == item) {

                    Debug.Log("stacked an " + item.name);
                    count[i] += 1;
                    if (onItemChangedCallback != null) {
                        onItemChangedCallback.Invoke();
                    }
                    needsNewSlot = false;
                }
            }
            if (needsNewSlot) {
                if (items.Count >= maxInventorySpace) { //if array is at capacity do not add the item
                    Debug.Log("max space (new slot error)");
                    return false;
                } else { //adds to a new slot otherwise
                    items.Add(item);
                    //Debug.Log("added a stackable" + item.name);
                    count.Add(1);

                    if (onItemChangedCallback != null) {
                        onItemChangedCallback.Invoke();
                    }
                }

            }
        } else {
            if (items.Count >= maxInventorySpace) {//if array is at capacity do not add the item
                Debug.Log("max space (stackable check)");
                return false;
            } else { //adds to a new slot otherwise
                items.Add(item);
                Debug.Log("added an unstackable " + item.name);
                count.Add(0); //adds 0 for debugging 
                if (onItemChangedCallback != null) {
                    onItemChangedCallback.Invoke();
                }
            }
        }
        return true;
    }
}
