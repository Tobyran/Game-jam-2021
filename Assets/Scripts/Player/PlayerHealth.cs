using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifes = 1, NroColores = 0;
    float AtackSpeed = 1f;
    public List<Dictionary<string, string>> colors = new List<Dictionary<string, string>>();
    Shield escudo;
    [SerializeField] GameObject rojo, azul, amarillo, verde;
    Player player;

    void Start()
    {
        escudo = GetComponent<Shield>();
        player = GetComponent<Player>();
    }


    void Update()
    {
        lifes = NroColores + 1;
        AtackSpeed += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Color"))
        {
            NroColores++;
        }

        if (collision.collider.CompareTag("Daño") && AtackSpeed >= 1f)
        {
            RecivirDaño();  
        }
    }

    private void RemoveRandomColor()
    {
        Dictionary<string, string> colorcito = colors[Random.Range(0, colors.Count)];
        colors.Remove(colorcito);

        switch (colorcito["effect"])
        {
            case "Slow":
                Espadazo sword = transform.Find("AttackPointBreve").GetComponent<Espadazo>();
                Espadazo sword2 = transform.Find("AttackPointAlto").GetComponent<Espadazo>();
                sword.capacidadRealentizar = false;
                sword2.capacidadRealentizar = false;
                azul.SetActive(false);
                player.azulb = false;
                break;
            case "Shield":
                GetComponent<Shield>().enabled = false;
                verde.SetActive(false);
                player.verdeb = false;
                break;
            case "FireBall":
                GetComponent<Fireball>().enabled = false;
                rojo.SetActive(false);
                player.rojob = false;
                break;
            case "Range":
                GetComponent<Range>().Ataquecorto();
                amarillo.SetActive(false);
                player.amarillob = false;
                break;
        }
    }

    private void RecivirDaño()
    {
        if (escudo.escudado)
        {
            escudo.escudado = false;
        }
        else
        {
            NroColores--;
            AtackSpeed = 0f;
            RemoveRandomColor();
        }
    }

}
