using UnityEngine;

public class PlayeAttack : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    private void Start() {
        weapon = transform.Find("WeaponHolder").GetComponent<WeaponHolder>().weapon;
    }
    public void Attack() {
        Debug.Log("attacking");
        weapon.Attack();
    }
}
