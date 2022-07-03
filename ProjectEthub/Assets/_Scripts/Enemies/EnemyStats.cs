using UnityEngine;
[CreateAssetMenu(menuName = "Scriptables/New Enemy", order = 3, fileName = "New Enemy")]
public class EnemyStats : ScriptableObject
{
    [Header("Basic Stats")]
    new public string name;
    public float health;
    public Item[] drops;
    public float damage;
    public float speed;
    [Header("Armor")]
    public bool isArmored;
    public float armor;
    [Header("Charging")]
    public float chargeSpeed;
    [Header("Zoning")]
    public float aggroDistance;
    public float attackDistance;
}
