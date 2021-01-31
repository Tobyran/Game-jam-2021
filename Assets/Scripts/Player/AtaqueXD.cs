using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueXD : MonoBehaviour
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float limite;
    float timer;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            attackPoint.SetActive(true);
        }

        if (timer >= limite)
        {
            attackPoint.SetActive(false);
        }

    }
}
