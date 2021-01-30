using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ListOfDoors

    List<Dictionary<string, object>> doors = new List<Dictionary<string, object>>();

    // Player
    public Player player;

    public GameObject playPanel;
    public Text interactions;

    // Door Colliders
    public GameObject mainDoor;
    public GameObject blueDoor;
    public GameObject redDoor;
    public GameObject yellowDoor;
    public GameObject pinkDoor;
    public GameObject bossDoor;

    // Areas

    public GameObject mainArea;
    public GameObject blueArea;
    public GameObject redArea;
    public GameObject yellowArea;
    public GameObject pinkArea;
    public GameObject bossArea;




    public static GameManager instance { get; set; }

    private void Awake()
    {

        doors.Add(MakeDoorDictionary(mainDoor.name, mainArea, false, new Vector3(-0.17f, -5.84f, -1f)));
        doors.Add(MakeDoorDictionary(bossDoor.name, bossArea, false, new Vector3(0, 35f, -1f)));
        doors.Add(MakeDoorDictionary(blueDoor.name, blueArea));
        doors.Add(MakeDoorDictionary(pinkDoor.name, pinkArea));
        doors.Add(MakeDoorDictionary(redDoor.name, redArea, true));
        doors.Add(MakeDoorDictionary(yellowDoor.name, yellowArea, true));

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

        Dictionary<string, object> selectedDoor = FindDoorInList(door.gameObject.name);
        player.transform.position = (Vector3)selectedDoor["vector"];
        //ColorsManager.instance.InstantiateColor("Red", new Vector3(41.9f, -24.2f, -1f));

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

    Dictionary<string, object> MakeDoorDictionary(string name, GameObject area, bool isLeft = false, Vector3? customVector = null)
    {
        if (customVector != null) return new Dictionary<string, object>
        {
            { "name", name },
            { "vector", customVector },

        };

        GameObject door = area.transform.Find("Main Door").gameObject;

        float xValue = door.transform.position.x;

        if (isLeft)
        {
            xValue -= 1;
        }
        else
        {
            xValue += 1;
        }

        return new Dictionary<string, object>
        {
            { "name", name },
            { "vector", new Vector3(xValue, door.transform.position.y, -1f) },

        };

    }

    Dictionary<string, object> FindDoorInList(string doorName)
    {

        foreach (Dictionary<string, object> dict in doors)
        {
            if ((string)dict["name"] == doorName)
            {
                return dict;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
