using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercombat : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator myamin;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public int attackdamge = 40;
    public float attackRate = 2f;
    float nextAttacktime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttacktime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttacktime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack()
    {
        myamin.SetTrigger("attack");
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemylayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit" + enemy.name);
            enemy.GetComponent<enemyhp>().takedamage(attackdamge);
           
        }
    }
     void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
