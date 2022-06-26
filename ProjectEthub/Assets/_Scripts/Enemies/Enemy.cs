using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;
    public float iFrameLength;
    public float health;
    void Start() {
        health = stats.health;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health == 0) {
            Die();
        }
    }
    private void Die() {
        Destroy(gameObject);
    }
}
