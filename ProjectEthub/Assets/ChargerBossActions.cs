using System.Collections;

using UnityEngine;

public class ChargerBossActions : MonoBehaviour {
    private EnemyStats stats;
    private Rigidbody2D rb;
    private Animator anim;

    private float speed;
    private GameObject target;

    private bool inAttackMode = false;


    private float distanceFromTarget;
    private float aggroDistance;
    private float attackDistance;

    private Coroutine currCo;
    void Start() {
        stats = gameObject.GetComponent<Charger>().stats;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

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

    public void EnterAttack() {
        anim.SetTrigger("EnterWindUp");
    }
    public void EnterCharge() {
        anim.SetBool("IsCharging", true);
        currCo = StartCoroutine(Charge());
    }

    IEnumerator Charge() {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction * stats.chargeSpeed, ForceMode2D.Force);
        yield return new WaitForSeconds(0.5f);
        direction = target.transform.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction * stats.chargeSpeed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        StopCoroutine(currCo);
        anim.SetBool("IsCharging", false);
        if (collision.collider.tag == "Player") {
            target.gameObject.GetComponent<PlayerBehavior>().TakeDamage(stats.chargeDamage);
            ReturnToIdle();
        }
        if (collision.collider.tag == "Wall") {
            anim.SetTrigger("Stun");
        }
    }

    public void ReturnToIdle() {
        anim.SetTrigger("ReturnToIdle");
    }
}
