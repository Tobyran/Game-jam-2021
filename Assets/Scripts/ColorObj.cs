using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObj : MonoBehaviour
{

    public Dictionary<string, string> color;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (ColorUtility.TryParseHtmlString(color["value"], out Color rgba))
        { renderer.color = rgba; }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            Debug.Log($"HEYY, i {color["name"]} color was touched by {collision.collider.name}");
        }
    }
}
