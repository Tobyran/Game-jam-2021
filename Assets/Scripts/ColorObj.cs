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


            string effect = color["effect"];

            if (effect == "IncreaseAttack") {
                PlayerCombat player = collision.collider.GetComponent<PlayerCombat>();
                player.attackBuff.gameObject.SetActive(true);
                player.CheckBuff(effect);
            }
            else if (effect == "IncreaseRange")
            {
                PlayerCombat player = collision.collider.GetComponent<PlayerCombat>();
                player.rangeBuff.gameObject.SetActive(true);
                player.CheckBuff(effect);
            }

            Destroy(gameObject);

        }
    }
}
