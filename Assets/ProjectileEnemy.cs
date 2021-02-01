using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{

    private List<GameObject> Bullets = new List<GameObject>();
    [SerializeField] Transform firepoint;
    public Transform player;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    public GameObject normalBullet;
    [SerializeField] float timer = 0f;
    public bool isFollowing = false;
    public float movSpeed = 5;
    //public EnemyController enemyController;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      // enemyController = GetComponent<EnemyController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        
    }

    private void FixedUpdate()
    {

        if (player.position.magnitude - transform.position.magnitude < 8 && timer >= 3)
        {
            Shoot();
        }
/*
        if (player.position.magnitude - transform.position.magnitude < 8)
        {
            enemyController.isFollowing = true;
        }
        */
    }

    

    void Shoot()
    {
        GameObject Bullet = Instantiate(normalBullet, firepoint.position, Quaternion.identity);
        Bullets.Add(Bullet);
        rigidBody = Bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(300f * movement);
        timer = 0f;
    }

}
