using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour {
    [HideInInspector]
    public Item item;
    [HideInInspector]
    public Weapon weapon;
    public Image icon;
    public Button slotButton;

    [SerializeField]
    private WeaponHolder weaponHolder;

    public void AddWeapon(Item newItem) {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        slotButton.interactable = true;
        weaponHolder.AddWeapon(item);
    }

    public void ClearSlot() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        slotButton.interactable = false;
        weaponHolder.RemoveWeapon();
    }
}
