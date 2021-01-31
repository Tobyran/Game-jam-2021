using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnColors : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)){
            ColorsManager.Instance.InstantiateColor(null, new Vector2(rigidbody.position.x +10, rigidbody.position.y) );
        }
    }
}
