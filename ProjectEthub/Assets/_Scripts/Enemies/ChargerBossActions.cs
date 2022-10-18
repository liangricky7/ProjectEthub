using System.Collections;

using UnityEngine;

public class ChargerBossActions : MonoBehaviour {
    private EnemyStats stats;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer render;

    private float speed;
    [SerializeField]
    private GameObject target;

    private float distanceFromTarget;
    private float attackDistance;
    private float attackCooldown;

    private bool isInAttack;
    private bool isInChase;
    private bool isBackingOff;
    private Vector3 retreatVector;

    private Coroutine currCo;
    private bool hitPlayer; //if true, then the thing hit in the charge is the player. if false, it hit a fellow enemy
    private Enemy enemyHit; //the enemy that the charge hits
    void Start() {
        stats = gameObject.GetComponent<Charger>().stats;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        render = gameObject.GetComponent<SpriteRenderer>();

        speed = stats.speed;
        target = PlayerManager.instance.player;

        attackDistance = stats.attackDistance;
        attackCooldown = stats.attackCooldown;

        isInAttack = false;

        hitPlayer = false;
    }

    void Update() {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (!isInAttack && distanceFromTarget <= attackDistance) {
            ReturnToIdle(); //resets isInChase
            EnterAttack();
        } else if (!isInAttack && !isBackingOff) {
            if (!isInChase) { //turns on the chase anim
                isInChase = true;
                anim.SetBool("isChase", true);
            }
            Chase();
        }
    }

    private void Look() {
        Vector3 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90) {
            render.flipX = true;
        } else {
            render.flipX = false;
        }
    }

    private void Chase() {
        Look();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void StartBackOff() {
        isBackingOff = true;
        float timeToWait = Time.time + attackCooldown;
        Debug.Log(attackCooldown);
        currCo = StartCoroutine(BackOff(timeToWait));

    }

    IEnumerator BackOff(float timeToWait) {
        while (Time.time < timeToWait || Vector3.Distance(transform.position, target.transform.position) > attackDistance) {
            retreatVector = new Vector3(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, transform.position + retreatVector, speed * Time.deltaTime);
            yield return null;
        }
        isBackingOff = false;
    }
    public void EnterAttack() {
        Look();
        anim.SetBool("isChase", false);
        isInAttack = true;
        anim.SetTrigger("EnterWindUp");
    }
    public void EnterCharge() {
        //Debug.Log("charging");
        anim.SetBool("IsCharging", true);
        currCo = StartCoroutine(Charge());
    }

    IEnumerator Charge() {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * stats.chargeSpeed;
        while (true) {
            yield return null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (currCo != null) {
            StopCoroutine(currCo);
        }
        if (anim.GetBool("IsCharging")) {

            anim.SetBool("IsCharging", false);
            if (collision.collider.tag == "Player") {
                anim.SetTrigger("Bash");
                hitPlayer = true;
                return;
            }
            if (collision.collider.tag == "Enemy") {
                enemyHit = collision.collider.GetComponent<Enemy>();
                anim.SetTrigger("Bash");
                hitPlayer = false;
                return;
            }
            if (collision.collider.tag == "Wall") {
                EnterStun();
            }
            //Debug.Log("collided");
        }

    }
    public void EnterStun() {
        rb.velocity = Vector2.zero;
        anim.SetTrigger("EnterStun");
        anim.SetBool("Stun", true);
        StartCoroutine(Stun());
    }
    IEnumerator Stun() {
        yield return new WaitForSeconds(2);
        anim.SetBool("Stun", false);
        ReturnToIdle();
    }

    public void Bash() {
        rb.velocity = Vector2.zero;
        if (hitPlayer) {
            target.gameObject.GetComponent<PlayerBehavior>().TakeDamage(stats.chargeDamage);
        } else {
            enemyHit.TakeDamage(stats.chargeDamage);
        }
    }

    public void ReturnToIdle() {
        isInChase = false;
        isInAttack = false;
        anim.SetTrigger("ReturnToIdle");
        rb.velocity = Vector2.zero;
    }
}
