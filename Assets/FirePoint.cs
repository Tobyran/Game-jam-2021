using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{

    [SerializeField] float timer = 0f;
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= 2.0f)
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            timer = 0f;
        }

    }
}
