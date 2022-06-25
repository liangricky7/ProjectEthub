using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/New Weapon", order = 2, fileName = "New Weapon")]
public class WeaponStats : ScriptableObject
{
    new public string name;
    public float damage;
    public Sprite sprite;
}
