using UnityEngine;

public class PlayeAttack : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    private void Start() {
        weapon = transform.Find("WeaponHolder").GetComponent<WeaponHolder>().weapon;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Attack();
        }
    }
    public void Attack() {
        weapon.Attack();
    }
}
