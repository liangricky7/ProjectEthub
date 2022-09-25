using System.Collections;

using UnityEngine;

public class ChargerBossActions : MonoBehaviour {
    private EnemyStats stats;
    private Rigidbody2D rb;
    private Animator anim;

    private float speed;
    [SerializeField]
    private GameObject target;

    private float distanceFromTarget;
    private float aggroDistance;
    private float attackDistance;

    private bool isInAttack;
    private bool isInChase;
    private Coroutine currCo;
    void Start() {
        stats = gameObject.GetComponent<Charger>().stats;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        speed = stats.speed;
        target = PlayerManager.instance.player;

        aggroDistance = stats.aggroDistance;
        attackDistance = stats.attackDistance;

        isInAttack = false;
    }

    void Update() {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (!isInAttack && distanceFromTarget <= attackDistance) {
            ReturnToIdle(); //resets isInChase
            EnterAttack();
        } else if (!isInAttack && distanceFromTarget <= aggroDistance) {
            if (!isInChase) {
                isInChase = true;
                anim.SetBool("isChase", true);
            }
            Chase();
        }
    }

    private void Look() {

    }

    private void EnterChase() {
    
    }
    private void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void EnterAttack() {
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
    private void OnCollisionEnter2D(Collision2D collision) {
        if (currCo != null) {
            StopCoroutine(currCo);
        }
        if (anim.GetBool("IsCharging")) {
            if (collision.collider.tag == "Enemy") {
                return;
            } 
            Debug.Log("enter charge collision");
            anim.SetBool("IsCharging", false);
            if (collision.collider.tag == "Player") {
                Debug.Log("player hit!");
                target.gameObject.GetComponent<PlayerBehavior>().TakeDamage(stats.chargeDamage);
                ReturnToIdle();
            }
            if (collision.collider.tag == "Wall") {
                EnterStun();
            }
            //Debug.Log("collided");
        }

    }

    private void BackOff() {
        
    }

    public void ReturnToIdle() {
        rb.velocity = Vector2.zero;
        isInChase = false;
        isInAttack = false;
        anim.SetTrigger("ReturnToIdle");
    }
}
