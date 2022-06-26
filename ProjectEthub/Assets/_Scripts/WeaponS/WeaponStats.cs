using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/New Weapon", order = 2, fileName = "New Weapon")]
public class WeaponStats : ScriptableObject
{
    new public string name;
    public float damage;
    public Sprite sprite;
    public float attackRange;
    public LayerMask enemyLayers;
}
