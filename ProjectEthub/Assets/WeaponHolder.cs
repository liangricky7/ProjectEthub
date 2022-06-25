using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    void Start()
    {
        weapon = transform.Find("WeaponPos").GetComponentInChildren<Weapon>();
    }
}
