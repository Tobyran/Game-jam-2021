using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{

    Rigidbody2D rb2d;
    float timer = 0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(Mathf.Clamp(3 * Time.deltaTime + 20, 0, 100) * (Vector2.down * 1));

        timer += Time.deltaTime;

        if (timer>=5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
