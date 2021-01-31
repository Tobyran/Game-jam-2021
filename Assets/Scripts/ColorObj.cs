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

            Player player = collision.collider.GetComponent<Player>();
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();

            string effect = color["effect"];

            switch(effect)
            {
                case "Slow":
                    player.GetComponent<Slow>().enabled = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Blue"));
                    break;
                case "Shield":
                    player.GetComponent<Shield>().enabled = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Green"));
                    break;
                case "FireBall":
                    player.GetComponent<Fireball>().enabled = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Red"));
                    break;
                case "Range":
                    player.GetComponent<Range>().enabled = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Yellow"));
                    break;
            }

           // player.CheckBuff(effect);

            Destroy(gameObject);

        }
    }
}
