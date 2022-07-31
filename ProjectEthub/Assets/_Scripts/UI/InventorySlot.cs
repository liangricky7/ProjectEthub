using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour {
    Item item;
    public Image icon;
    public Image slotFill;
    public TextMeshProUGUI countText;
    public Button slotButton;

    private SlotSelector slotSelector;

    [SerializeField]
    private WeaponSlot weaponSlot;

    public int slotID;
    private void Start() {
        slotSelector = SlotSelector.instance;
        slotSelector.onSelectionChangeCallback += UpdateSlot;
    }

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

    public void Select() {
        SlotSelector.instance.SelectSlot(gameObject, slotID);
    }

    public void UpdateSlot() { //controls highlight
        if (slotSelector.currentID != slotID) {
            slotFill.color = new Color(211f / 255f, 150f / 255f, 93f / 255f, 1);
        } else {
            slotFill.color = new Color(255f / 255f, 179f / 255f, 88f / 255f, 1);
        }
    }

    public void Equip() {
        if (item != null) {
            Debug.Log(slotID);
            //do nothing
        } else {
            return;
        }
        if (item.isWeapon) {
            //InventorySlotManager.instance.WeaponSlot;
            InventorySlotManager.instance.EquipWeapon(item);
            Inventory.instance.Remove(item);
            SlotSelector.instance.SelectSlot(gameObject, SlotSelector.instance.currentID); //unselects the slot
        }
    }
}
