using UnityEngine;
[CreateAssetMenu(menuName = "Scriptables/New Enemy", order = 3, fileName = "New Enemy")]
public class EnemyStats : ScriptableObject
{
    new public string name;
    public float health;
    public Item[] drops;
    public float damage;
    public float speed;
    public bool isArmored;
    public float armor;
}
