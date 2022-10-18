using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {
    public GameObject parent;
    public Transform attackPoint;

    private Animator anim;

    public bool inAttack;
    private float damage;
    private float attackDistance;

    private LayerMask playerLayer;
    private Coroutine currCo;
    void Awake() {
        inAttack = false;
        anim = gameObject.GetComponent<Animator>();
    }
    private void Start() {
        attackDistance = parent.GetComponent<WindBanditMelee>().stats.attackDistance;
    }

    public void Attack() {
        inAttack = true;
        anim.SetBool("Attack", true);
    }
    private void StartCheck() {
        currCo = StartCoroutine(Check());
    }
    public IEnumerator Check() {
        while (true) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDistance, playerLayer);
            foreach (Collider2D enemy in hitEnemies) {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
            yield return null;
        }
    }

}
