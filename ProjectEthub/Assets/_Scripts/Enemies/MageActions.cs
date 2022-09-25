using System.Collections;

using UnityEngine;

public class MageActions : MonoBehaviour {
    private EnemyStats stats;
    private Rigidbody2D rb;
    private Animator anim;

    private float speed;
    [SerializeField]
    private GameObject target;

    private float distanceFromTarget;
    private float aggroDistance;
    private float attackDistance;
    private float retreatDistance;

    private bool isInAttack;
    private bool isInChase;
    private Coroutine currCo;

    private Vector3 retreatVector;
    void Start() {
        stats = gameObject.GetComponent<Mage>().stats;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        speed = stats.speed;
        target = PlayerManager.instance.player;

        aggroDistance = stats.aggroDistance;
        Debug.Log(aggroDistance);
        attackDistance = stats.attackDistance;
        retreatDistance = stats.attackDistance * 0.6f;
        isInAttack = false;
    }

    void Update() {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (!isInAttack && distanceFromTarget <= retreatDistance) {
            Retreat();
        }
        if (!isInAttack && distanceFromTarget <= attackDistance) {
            Attack();
        } else if (!isInAttack && distanceFromTarget <= aggroDistance) {
            Chase();
        }
    }

    private void Look() {

    }

    private void Chase() {
        anim.SetBool("isWalk", true);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void EnterAttack() {
        anim.SetBool("isWalk", false);
        anim.SetTrigger("ReturnToIdle"); //resets all anims
        isInAttack = true;
        ExitAttack();
    }
    public void Attack() {
    
    }

    public void ExitAttack() {
        isInAttack = false;
    }

    private void Retreat() {
        anim.SetBool("isWalk", true);
        retreatVector = new Vector3(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, transform.position + retreatVector, speed * Time.deltaTime);

    }

    public void ReturnToIdle() {
        rb.velocity = Vector2.zero;
        isInChase = false;
        isInAttack = false;
        anim.SetTrigger("ReturnToIdle");
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.DrawWireSphere(transform.position, retreatDistance);

    }
}
