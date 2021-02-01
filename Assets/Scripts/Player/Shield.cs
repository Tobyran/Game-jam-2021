using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool escudado;
    private float cooldown = 3f, timer = 0f;
    [SerializeField] GameObject escudazo;

    void Start()
    {
        escudado = true;
        escudazo.SetActive(true);
    }


    void Update()
    {

        if (escudado == false)
        {
            timer += Time.deltaTime;
            escudazo.SetActive(false);
        }

        if (escudado == false && timer >= cooldown)
        {
            escudado = true;
            timer = 0f;
            escudazo.SetActive(true);
        }

    }
}
