using System.Collections;

using UnityEngine;

public class ChargerActions : MonoBehaviour {
    private EnemyStats stats;

    private float speed;
    private GameObject target;

    private bool inAttackMode = false;

    private float distanceFromTarget;
    private float aggroDistance;
    private float attackDistance;

    private Coroutine currCo;
    void Start() {
        stats = gameObject.GetComponent<Charger>().stats;

        speed = stats.speed;
        target = PlayerManager.instance.player;

        aggroDistance = stats.aggroDistance;
        attackDistance = stats.attackDistance;
    }

    void Update() {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (!inAttackMode && distanceFromTarget <= attackDistance) {
            EnterAttack();
        } else if (distanceFromTarget <= aggroDistance) {
            Chase();
        }
    }
    private void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void EnterAttack() {

    }
}
