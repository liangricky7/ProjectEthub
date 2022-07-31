using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public bool weaponEquipped;
    
    public Transform weaponPos;
    private PrefabManager prefabManager;
    public Weapon weapon;

    void Start()
    {
        prefabManager = PrefabManager.instance;
        weaponPos = transform.Find("WeaponPos");
    }

    public void AddWeapon(Item item) {

        GameObject newWeapon = Instantiate(prefabManager.Weapons[item.itemID], weaponPos);
        weapon = newWeapon.GetComponent<Weapon>();
        weaponEquipped = true;
    }
    public void RemoveWeapon() {
        weaponEquipped = false;
    }
}
