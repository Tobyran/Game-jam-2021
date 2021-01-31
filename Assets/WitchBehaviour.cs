using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBehaviour : MonoBehaviour
{

    public string[] Witchstates = new string[] { "round", "line", "projectile" };

    Random random = new Random();
    [SerializeField] int randomNumber;
    [SerializeField] float timer = 0f;

    [SerializeField] GameObject Round;
    [SerializeField] GameObject Lines;
    [SerializeField] GameObject[] Points;

    [SerializeField] GameObject bullets;

    Transform initialPosition;


    void Start()
    {

        initialPosition = gameObject.transform;
        randomNumber = Random.Range(0, 3);

    }
    


    void Update()
    {

        if (randomNumber == 0)
        {

            RoundAttack();
            timer += Time.deltaTime;

        }

        if (randomNumber == 1)
        {

            LineAttack();
            timer += Time.deltaTime;

        }

        if (randomNumber == 2)
        {

            ProjectileAttack();
            timer += Time.deltaTime;

        }

    }

    void RoundAttack()
    {

        

            Round.SetActive(true);

        

        if (timer >= 5f)
        {
            randomNumber = Random.Range(0, 3);
            Round.SetActive(false);
            timer = 0f;
        }

    }

    void LineAttack()
    {

        

            Lines.SetActive(true);

        

        if (timer >= 5f)
        {
            randomNumber = Random.Range(0, 3);
            Lines.SetActive(false);
            timer = 0f;
        }

    }

    void ProjectileAttack()
    {

        if (timer <= 5f)
        {

            gameObject.transform.position = new Vector3(0, 50, 0);

        }

        for (int i = 0; i < Points.Length; i++)
        {

            Points[i].SetActive(true);

        }

        if (timer >= 5f)
        {
                        
            for (int i = 0; i < Points.Length; i++)
            {

                Points[i].SetActive(false);

            }
            
            randomNumber = Random.Range(0, 3);
            gameObject.transform.position = new Vector3(0, 40, 0);
            timer = 0f;           

        }

    }

}
