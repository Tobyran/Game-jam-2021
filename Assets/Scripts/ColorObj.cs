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
            Espadazo sword = player.transform.Find("AttackPointBreve").GetComponent<Espadazo>();
            Espadazo sword2 = player.transform.Find("AttackPointAlto").GetComponent<Espadazo>();

            string effect = color["effect"];

            switch(effect)
            {
                case "Slow":
                    sword.capacidadRealentizar = true;
                    sword2.capacidadRealentizar = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Blue"));
                    player.azulb = true;
                    break;
                case "Shield":
                    player.GetComponent<Shield>().enabled = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Green"));
                    player.verdeb = true;
                    break;
                case "FireBall":
                    player.GetComponent<Fireball>().enabled = true;
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Red"));
                    player.rojob = true;
                    break;
                case "Range":
                    player.GetComponent<Range>().AtaqueLargo();
                    playerHealth.colors.Add(ColorsManager.Instance.FindColorInList("Yellow"));
                    player.amarillob = true;
                    break;
            }

            Destroy(gameObject);

        }
    }
}
