using UnityEngine;

public class MageActions : MonoBehaviour {
    //attached stuffs
    [HideInInspector]
    public EnemyStats stats;
    private Animator anim;
    private SpriteRenderer render;

    [SerializeField]
    private GameObject target;
    //stats and whatnot
    private float speed;
    private float distanceFromTarget;
    private float aggroDistance;
    private float attackDistance;
    private float retreatDistance;
    //atk cd
    private float attackCooldown;
    private float nextAttackTime;
    //states
    private bool isInAttack;
    private bool isInChase;
    //retreat
    private Vector3 retreatVector;
    //any references to certain points
    public GameObject MageCast;
    public GameObject firePoint;
    void Start() {
        stats = gameObject.GetComponent<Mage>().stats;
        anim = gameObject.GetComponent<Animator>();
        render = gameObject.GetComponent<SpriteRenderer>();

        target = PlayerManager.instance.player;

        speed = stats.speed;
        aggroDistance = stats.aggroDistance;
        attackDistance = stats.attackDistance;
        retreatDistance = stats.attackDistance * 0.6f;

        attackCooldown = stats.attackCooldown;
        isInAttack = false;
    }

    void Update() {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (!isInAttack && distanceFromTarget <= retreatDistance) {
            Retreat();
        }
        if (!isInAttack && distanceFromTarget <= attackDistance) {
            Attack();
        } else if (!isInAttack) {  //&& distanceFromTarget <= aggroDistance (leave this out for now)
            Chase();
        } else if (isInChase) { //reset everything when player leaves range
            ReturnToIdle();
            isInChase = false;
        }
    }
    private void Look() {
        Vector3 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90) {
            render.flipX = false;
        } else {
            render.flipX = true;
        }
    }
    private void LookRetreat() {
        Vector3 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90) {
            render.flipX = true;
        } else {
            render.flipX = false;
        }
    }


    private void Chase() {
        isInChase = true;
        anim.SetBool("isWalk", true);
        Look();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void Attack() {
        if (Time.time >= nextAttackTime) {
            isInChase = false;
            anim.SetBool("Attack", true);
        } 
    }

    public void EnterAttack() {
        Look();
        Debug.Log("mage attacking!");
        anim.SetBool("isWalk", false);
        anim.SetTrigger("ReturnToIdle"); //resets all anims
        isInAttack = true;
        ExitAttack();
        ReturnToIdle();
    }

    public void Cast() {
        Debug.Log("shot a ball");
        Instantiate(MageCast, firePoint.transform.position, firePoint.transform.rotation);
    }

    public void ExitAttack() {
        Look();
        anim.SetBool("Attack", false);
        ReturnToIdle();
        isInAttack = false;
        nextAttackTime = Time.time + attackCooldown;
    }

    private void Retreat() {
        isInChase = false;
        anim.SetBool("isWalk", true);
        LookRetreat();
        retreatVector = new Vector3(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, transform.position + retreatVector, speed * Time.deltaTime);

    }

    public void ReturnToIdle() {
        isInAttack = false;
        anim.SetBool("isWalk", false);
        anim.SetTrigger("ReturnToIdle");
    }

    //private void OnDrawGizmos() {
    //    Gizmos.DrawWireSphere(transform.position, aggroDistance);
    //    Gizmos.DrawWireSphere(transform.position, attackDistance);
    //    Gizmos.DrawWireSphere(transform.position, retreatDistance);

    //}
}
