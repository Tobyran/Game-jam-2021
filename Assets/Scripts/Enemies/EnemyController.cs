using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lifes = 5;
    public float movSpeed = 5;
    public Transform player;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    public bool isFollowing = false;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidBody.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            MoveCharacter(movement);

        }
    }

    void MoveCharacter(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * movSpeed * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {

        lifes -= damage;

        if (lifes <= 0)
        {
            Debug.Log("enemy dead");
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = false;
        }
    }


}
