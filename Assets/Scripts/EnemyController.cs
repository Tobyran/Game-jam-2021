using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float life = 5;
    Player player;

    void Start()
    {
        
    }

    void Update()
    {
        
        
    }

    public void TakeDamage(float damage)
    {

        life -= damage;

        if (life <= 0)
        {
            Debug.Log("enemy dead");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            player.lifes--;
        }
    }


}
