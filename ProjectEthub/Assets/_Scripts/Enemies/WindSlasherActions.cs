using System.Collections;

using UnityEngine;

public class WindSlasherActions : MonoBehaviour
{
    private EnemyStats stats;

    private float speed;
    private GameObject target;

    private bool isPatrolling = false;
    private bool inAttackMode = false;

    public GameObject patrolZoneObject;
    private Bounds patrolZone;
    private Vector3 patrolPoint;
    private float patrolRange = 5f;
    private float waitTime;

    private float distanceFromTarget;
    private float aggroDistance;
    private float attackDistance;

    private Coroutine currCo;
    void Start()
    {
        stats = gameObject.GetComponent<WindSlasher>().stats;

        speed = stats.speed;
        target = PlayerManager.instance.player;

        patrolZone = new Bounds(patrolZoneObject.transform.position, patrolZoneObject.GetComponent<BoxCollider2D>().size);

        aggroDistance = stats.aggroDistance;
        attackDistance = stats.attackDistance;
    }

    void Update()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(distanceFromTarget);
        if (!inAttackMode && distanceFromTarget <= attackDistance) {
            EnterAttack();
        } else if (distanceFromTarget <= aggroDistance) {
            Chase();
        } else if (!isPatrolling) {
            EnterPatrol();
        }
    }

    private void EnterPatrol() {
        isPatrolling = true;
        currCo = StartCoroutine(Patrol());
    }

    IEnumerator Patrol() {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        FindPatrolPoint();
        while (transform.position != patrolPoint) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint, speed * Time.deltaTime);
            yield return null;
        }
        
        isPatrolling = false;
    }
    private void FindPatrolPoint() {
        patrolPoint = new Vector2(transform.position.x + Random.Range(-patrolRange, patrolRange), transform.position.y + Random.Range(-patrolRange, patrolRange));
    }
    private void Chase() {
        if (isPatrolling) {
            StopCoroutine(currCo);
            isPatrolling = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void EnterAttack() {
        inAttackMode = true;
        if (isPatrolling) {
            StopCoroutine(currCo);
            isPatrolling = false;
        }
        Debug.Log("entered Attacking");
    }
}
