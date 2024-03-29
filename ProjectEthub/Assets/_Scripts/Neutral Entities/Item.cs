using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/New Item", order = 1, fileName = "New Item")]
public class Item : ScriptableObject {
    new public string name = "Item name"; //all objects inherently have a name field
    public Sprite icon = null;
    public bool isStackable = true;
    public int itemID;
    [Header("Weapon")]
    public bool isWeapon;
    [Header("Accessory")]
    public bool isAccessory;
    [Header("Potion")]
    public bool isPotion;

}
