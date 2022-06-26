using UnityEngine;
public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI; //subscribes the update function to the itemchangedcallback

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    void UpdateUI() {
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.items.Count) { //there are more items to add
                slots[i].AddItem(inventory.items[i], inventory.count[i]);
            } else {
                slots[i].ClearSlot(); //handles the event in which an item is deleted
            }
        }
    }
}
