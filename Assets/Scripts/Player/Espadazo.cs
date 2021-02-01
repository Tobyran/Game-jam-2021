using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadazo : MonoBehaviour
{
    [SerializeField] int daño = 0, probabilidadslow = 0;
    public bool capacidadRealentizar;

    private void Start()
    {
        capacidadRealentizar = false;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Daño"))
        {
            if (capacidadRealentizar)
            {
                probabilidadslow = Random.Range(1, 4);
            }

            EnemyController dañino = other.GetComponent<EnemyController>();
            dañino.TakeDamage(daño);
            Debug.Log("ATAKU");

            if (probabilidadslow == 1)
            {
                dañino.Realentizado();
                Debug.Log("Realentizado xd xd xd");
            }
        }
    }

}
