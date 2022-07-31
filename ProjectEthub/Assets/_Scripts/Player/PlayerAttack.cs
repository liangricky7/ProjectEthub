using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponHolder weaponHolder;
    private void Start() {
        weaponHolder = transform.Find("WeaponHolder").GetComponent<WeaponHolder>();
    }
    public void Attack() {
        if (weaponHolder.weaponEquipped) {
            weaponHolder.weapon.Attack();
        } else {
            Debug.Log("no weapon!");
        }
    }
}
