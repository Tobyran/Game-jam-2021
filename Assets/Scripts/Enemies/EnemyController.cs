using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lifes = 5;
    public float movSpeed = 5;
    private float movspeedinicial;
    public Transform player;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    public bool isFollowing = false;
    Vector3 startPos;
    Slow slow;
    SpriteRenderer color;
    [SerializeField] float tiempodeslow, timer = 0f;
    [SerializeField] bool lento;
    [SerializeField] int puntos;
    GameManager manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPos = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        slow = GameObject.FindGameObjectWithTag("Player").GetComponent<Slow>();
        color = GetComponent<SpriteRenderer>();
        movspeedinicial = movSpeed;
    }

    void Update()
    {

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        startPos.Normalize();
        movement = direction;

        if (lento)
        {
            timer += Time.deltaTime;
        }

        if (timer >= tiempodeslow)
        {
            AdiosLento();
        }

    }

    private void FixedUpdate()
    {

        if (player.position.magnitude - transform.position.magnitude < 8)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

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
            Destroy(gameObject);
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

    public void Realentizado()
    {
        lento = true;
        if(ColorUtility.TryParseHtmlString("#4362b5", out Color rgba))
        { color.color = rgba; }
        movSpeed = movSpeed / 2;
    }

    private void AdiosLento()
    {
        lento = false;
        timer = 0f;
        color.color = new Color(1, 1, 1, 1);
        movSpeed = movspeedinicial;
    }

}
