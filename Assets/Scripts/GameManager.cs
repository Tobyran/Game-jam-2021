using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Dictionary<Collider2D, GameObject> doors;
    public GameObject playPanel;
    public Text interactions;
    public GameObject blueDoor;
    private bool isMainScene = true;
    public static GameManager instance { get; set; }

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InteractWithDoor(Collider2D door)
    {

        Debug.Log("Interacting...");
    }

    public void ShowDoorMessage(Collider2D door, bool isStaying)
    {
        if (isStaying)
        {
            interactions.text = $"Press E to interact with: {door.name}";

        }
        else
        {
            interactions.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
