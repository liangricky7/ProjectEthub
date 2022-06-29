using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour {
    Item item;
    public Image icon;
    public TextMeshProUGUI countText;

    public void AddItem(Item newItem, int count) {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        if (newItem.isStackable && count > 1)
            countText.text = count.ToString();
    }

    public void ClearSlot() {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        countText.ClearMesh();
    }
}
