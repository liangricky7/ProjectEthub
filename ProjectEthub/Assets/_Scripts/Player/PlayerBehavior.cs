using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float health = 100;

    private void Awake() {
        UIElementManager.instance.HealthBar.GetComponent<HealthBar>().SetMaxHealth(health);
    }
    
    public void TakeDamage(float damage) {
        health -= damage;
        UIElementManager.instance.HealthBar.GetComponent<HealthBar>().SetHealth(health);
        if (health < 0) {
            Die();    
        }
    }

    private void Die() {
        Debug.Log("player died");
    }
}
