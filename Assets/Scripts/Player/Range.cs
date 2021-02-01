using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{

    AtaqueXD corto;
    AtaqueLargo largo;

    void Awake()
    {
        corto = GetComponent<AtaqueXD>();
        largo = GetComponent<AtaqueLargo>();
    }

    public void Ataquecorto()
    {
        corto.enabled = true;
        largo.enabled = false;
    }

    public void AtaqueLargo()
    {
        corto.enabled = false;
        largo.enabled = true;
    }

}
