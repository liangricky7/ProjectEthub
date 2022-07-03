using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour {
    Item item;
    public Image icon;
    public TextMeshProUGUI countText;

    public Button slotButton;

    public void AddItem(Item newItem, int count) {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        slotButton.interactable = true;

        if (newItem.isStackable && count > 1)
            countText.text = count.ToString();
    }

    public void ClearSlot() {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        slotButton.interactable = false;
        countText.ClearMesh();
    }

    public void Equip() {
        if (item != null) {
            //do nothing
        } else {
            return;
        }
        if (item.isWeapon) {
            //InventorySlotManager.instance.WeaponSlot;
            Inventory.instance.Remove(item);
        }
    }
}
