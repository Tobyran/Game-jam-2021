using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalAxis;
    private float verticalAxis;
    public float movSpeed;
    private Rigidbody2D rigidBody;
    public int lifes;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    
       
    }

    // Update is called once per frame
    void Update()
    {
      
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Physics2D.gravity = Vector2.zero;
        rigidBody.gravityScale = 0.0f;
        rigidBody.velocity = new Vector2(horizontalAxis * movSpeed, verticalAxis * movSpeed);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Door")
        {
            GameManager.instance.ShowDoorMessage(collision.collider, true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.InteractWithDoor(collision.collider);
            }
        }
      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Door")
        {
            GameManager.instance.ShowDoorMessage(collision.collider, false);
        }
    }
}
