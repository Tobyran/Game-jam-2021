using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    public GameObject NormalBullet;
    
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {

        if (player.position.magnitude - transform.position.magnitude < 8)
        {
            Shoot();
        }
       
    }

    void Shoot()
    {

        Instantiate(NormalBullet, transform.position, Quaternion.identity);

    }

}
