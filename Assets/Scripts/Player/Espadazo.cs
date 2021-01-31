using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadazo : MonoBehaviour
{
    [SerializeField] int daño = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Daño"))
        {
            Debug.Log("ATAKU");
        }
    }
}
