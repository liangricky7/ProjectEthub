using System.Collections;

using UnityEngine;

public class WindBanditMeleeActions : MonoBehaviour
{
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
    public GameObject rotateDaggerObject;
    public RotateAboutTargetEnemy rotateDagger;
    public EnemyMelee windBanditDagger;
    void Start()
    {
        stats = gameObject.GetComponent<WindBanditMelee>().stats;

        speed = stats.speed;
        target = PlayerManager.instance.player;

        //patrolZone = new Bounds(patrolZoneObject.transform.position, patrolZoneObject.GetComponent<BoxCollider2D>().size);

        aggroDistance = stats.aggroDistance;
        attackDistance = stats.attackDistance;
    }

    void Update() {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (!isInAttack && distanceFromTarget <= attackDistance) {
            EnterAttack();
        } else if (distanceFromTarget <= aggroDistance) {
            Chase();
            rotateDaggerObject.SetActive(true);
            rotateDagger.Activate();
        } else {
            rotateDagger.Deactivate();
        }
    }
    private void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void EnterAttack() {
        windBanditDagger.Attack();
        Debug.Log("entered Attacking");
    }
}
