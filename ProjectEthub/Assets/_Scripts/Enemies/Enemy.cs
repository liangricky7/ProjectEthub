using UnityEngine;

public class Enemy : MonoBehaviour
{
    public virtual void TakeDamage(float damage) {
        Debug.Log("took " + damage + " damage");
    }
}
