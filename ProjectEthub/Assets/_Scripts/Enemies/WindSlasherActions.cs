using UnityEngine;

public class WindSlasherActions : MonoBehaviour
{
    private float speed;
    private GameObject target;
    void Start()
    {
        speed = gameObject.GetComponent<WindSlasher>().stats.speed;
        target = PlayerManager.instance.player;
    }

    void Update()
    {
        
    }

    private void Patrol() {
    
    }

    private void Chase() {
    
    }

    private void Attack() {
        
    }
}
