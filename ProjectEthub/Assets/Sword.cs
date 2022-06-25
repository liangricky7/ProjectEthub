using UnityEngine;

public class Sword : Weapon
{
    private Animator anim;
    
    public WeaponStats stats;
    private float damage;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        damage = stats.damage;
    }
    public override void Attack() {
        if (!anim.GetBool("Attack1")) {
            anim.SetBool("Attack1", true);
        } else {
            return;
        }
    }
    private void StartCheck() {
    
    }

    private void EndCheck() {
        
    }
    private void EndAttack() {
        anim.SetBool("Attack1", false);
        anim.SetTrigger("ReturnIdle");
    }
}
