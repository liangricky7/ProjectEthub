using UnityEngine;

public class InventorySlotManager : MonoBehaviour
{
    [SerializeField]
    private WeaponSlot weaponSlot;
    #region Singleton
    public static InventorySlotManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion
    public void EquipWeapon(Item newItem) {
        if (weaponSlot.item != null) {
            Inventory.instance.Add(newItem);
            weaponSlot.ClearSlot();
        }
        weaponSlot.AddWeapon(newItem);
    }
    public void EquipAccessory() {

    }

}
