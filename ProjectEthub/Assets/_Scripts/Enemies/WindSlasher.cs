using UnityEngine;

public class WindSlasher: Enemy
{
    public EnemyStats stats;
    private float iFrameLength;
    private float nextTimeCanDamage;
    public float health;
    private GameObject itemPickup;

    void Start() {
        health = stats.health;
        iFrameLength = 0.4f;
        itemPickup = PrefabManager.instance.ItemPickup;
    }

    public override void TakeDamage(float damage) {
        if (Time.time >= nextTimeCanDamage) {
            Debug.Log("ouch");
            health -= damage;
            nextTimeCanDamage = Time.time + iFrameLength;
        }
        if (health == 0) {
            Die();
        }
    }
    private void Die() {
        foreach (Item item in stats.drops) {
            GameObject pickup = Instantiate(itemPickup, transform.position, transform.rotation);
            pickup.GetComponent<ItemPickup>().Initialize(item);
        }
        Destroy(gameObject);
    }
}
