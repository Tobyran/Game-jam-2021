using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalAxis;
    private float verticalAxis;
    public float movSpeed = 5f;
    private Rigidbody2D rigidBody;
    public int lifes = 2;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if (horizontalAxis > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        if (horizontalAxis < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        if (verticalAxis > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (verticalAxis < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }

        if (lifes <= 0)
        {
            Debug.Log("Player dead");
        }



    }

    private void FixedUpdate()
    {
        Physics2D.gravity = Vector2.zero;
        rigidBody.gravityScale = 0.0f;
        rigidBody.velocity = new Vector2(horizontalAxis * movSpeed, verticalAxis * movSpeed);

    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Door"))
        {
            GameManager.Instance.ShowDoorMessage(collision.collider, true);


            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.InteractWithDoor(collision.collider);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {


            GameManager.Instance.ShowDoorMessage(collision.collider, false);
        }
    }

}
