using System.Collections;
using UnityEngine;

public class Sword : Weapon
{
    private Animator anim;
    private Transform attackPoint;
    private LayerMask enemyLayers;
    private bool inAttack;

    public WeaponStats stats;
    private float damage;

    Coroutine coroutine;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        damage = stats.damage;
        enemyLayers = stats.enemyLayers;
        attackPoint = transform.Find("AttackPoint");
    }
    public override void Attack() {
        if (!inAttack) {
            inAttack = true;
            anim.SetTrigger("Attack1");
        } else {
            return;
        }
    }
    private void StartCheck() {
        this.coroutine = StartCoroutine(Check());
    }
    public IEnumerator Check() {
        while (true) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, stats.attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies) {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
            yield return null;
        }
    }
    private void EndCheck() {
        StopCoroutine(this.coroutine);
    }
    private void EndAttack() {
        anim.SetTrigger("ReturnIdle");
        inAttack = false;
    }
}
