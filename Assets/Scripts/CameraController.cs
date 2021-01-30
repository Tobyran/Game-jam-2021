using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private void Start()
    {
        transform.position = new Vector3(0f, -5f, -1f);
    }

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1f);
    }


}
