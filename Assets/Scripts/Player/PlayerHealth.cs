using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifes = 1, NroColores = 0;
    float AtackSpeed = 1f;
    public List<Dictionary<string, string>> colors = new List<Dictionary<string, string>>();

    void Start()
    {
        
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
            NroColores--;
            AtackSpeed = 0f;
            RemoveRandomColor();
        }
    }

    private void RemoveRandomColor()
    {
        Dictionary<string, string> colorcito = colors[Random.Range(0, colors.Count)];
        colors.Remove(colorcito);

        switch (colorcito["effect"])
        {
            case "Slow":
                GetComponent<Slow>().enabled = false;              
                break;
            case "Shield":
                GetComponent<Shield>().enabled = false;               
                break;
            case "FireBall":
                GetComponent<Fireball>().enabled = false;               
                break;
            case "Range":
                GetComponent<Range>().enabled = false;                
                break;
        }

    }



}
