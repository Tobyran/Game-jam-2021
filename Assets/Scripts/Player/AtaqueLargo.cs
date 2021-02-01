using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueLargo : MonoBehaviour
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float limite = 0.15f, atkspeed;
    float timer = 0f, speed = 10f;
    Animator anim;
    bool cooldown;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        speed += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && speed >= atkspeed)
        {
            attackPoint.SetActive(true);
            anim.SetBool("Ataku", true);
            cooldown = true;
            speed = 0f;
        }

        if (timer >= limite)
        {
            attackPoint.SetActive(false);
            anim.SetBool("Ataku", false);
            cooldown = false;
            timer = 0f;
        }

        if (cooldown)
        {
            timer += Time.deltaTime;
        }
    }
}
