using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float health = 100;
    public void TakeDamage(float damage) {
        health -= damage;
        if (health < 0) {
            Die();    
        }
    }

    private void Die() {
        Debug.Log("player died");
    }
}
