using UnityEngine;
public class SlotSelector : MonoBehaviour
{
    public InventorySlot inventorySlot;
    public int currentID;

    #region Singleton
    public static SlotSelector instance;

    private void Awake() {
        currentID = -1;
        instance = this;
    }
    #endregion

    public delegate void OnSelectionChange(); //creates the event where theres an item change
    public OnSelectionChange onSelectionChangeCallback;
    public void SelectSlot(GameObject slot, int slotID) {
        if (currentID != slotID) { 
            inventorySlot = slot.GetComponent<InventorySlot>();
            currentID = slotID;
        } else { //deselect
            inventorySlot = null;
            currentID = -1;
        }
        if (onSelectionChangeCallback != null) {
            onSelectionChangeCallback.Invoke();
        }
    }
    public void Equip() {
        if (currentID < 0) {
            return;
        }
        Debug.Log("attempt equip");
        inventorySlot.Equip();
    }
}
