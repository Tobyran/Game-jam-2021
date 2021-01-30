using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObj : MonoBehaviour
{

    public Dictionary<string, string> color;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (ColorUtility.TryParseHtmlString(color["value"], out Color rgba))
        { renderer.color = rgba; }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            PlayerCombat player = collision.collider.GetComponent<PlayerCombat>();

            string effect = color["effect"];

            switch(effect)
            {
                case "IncreaseAttack":
                    player.attackBuff.gameObject.SetActive(true);
                    break;
                case "IncreaseRange":
                    player.rangeBuff.gameObject.SetActive(true);
                    break;
            }

            player.CheckBuff(effect);

            Destroy(gameObject);

        }
    }
}
