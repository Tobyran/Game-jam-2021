using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreasStruct : MonoBehaviour
{
    public GameObject area;
    public Vector3 customCoords;

    public AreasStruct(GameObject area, Vector3 customCoords)
    {
        this.area = area;
        this.customCoords = customCoords;
    }
}
