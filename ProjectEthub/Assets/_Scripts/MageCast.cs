using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageCast : MonoBehaviour
{
    private float damage;
    private GameObject target;
    private float speed;
    [SerializeField]
    private EnemyStats stats;
    private Coroutine corou;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player;
        damage = stats.damage;
        speed = 2;
        corou = StartCoroutine(DestroyTimer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    IEnumerator DestroyTimer() {
        yield return new WaitForSeconds(5);
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            collision.collider.GetComponent<PlayerBehavior>().TakeDamage(damage);
        }
        StopCoroutine(corou);
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }
}
