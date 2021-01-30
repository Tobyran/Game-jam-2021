using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    public float attackRange = 0.05f;
    public float attackDamage = 1f;
    public LayerMask enemyLayers;
    public Buff attackBuff;
    public Buff rangeBuff;


    private void Start()
    {


    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    public void CheckBuff(string effect)
    {
        if (effect == "IncreaseAttack")
        {
            if (!attackBuff.isActiveAndEnabled)
            {
                attackDamage += attackBuff.value;
            }
            else
            {
                attackDamage -= attackBuff.value;
            }
        }
        else if (effect == "IncreaseRange")
        {
            if (!rangeBuff.isActiveAndEnabled)
            {
                attackRange += rangeBuff.value;
            }
            else
            {
                attackRange -= rangeBuff.value;
            }
        }
    }





}
