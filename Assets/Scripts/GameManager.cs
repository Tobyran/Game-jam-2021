using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ListOfDoors

    List<Dictionary<string, object>> doors = new List<Dictionary<string, object>>();

    // ListOfMaps

    List<Dictionary<string, object>> maps = new List<Dictionary<string, object>>();

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

    // Maps
    public GameObject parentMap;
    public GameObject map1;

    public static GameManager Instance { get; set; }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {

        maps.Add(MakeMapDictionary("Base", map1, new List<Vector2>() { new Vector2(-45.96546f, -24.4639f), new Vector2(-45.96546f, 5.043973f), new Vector2(43.59225f, 5.281386f), new Vector2(43.59225f, -23.89389f) }));
        doors.Add(MakeDoorDictionary(mainDoor.name, mainArea, false, new Vector3(-0.17f, -5.84f, -1f)));
        doors.Add(MakeDoorDictionary(bossDoor.name, bossArea, false, new Vector3(0, 35f, -1f)));
        doors.Add(MakeDoorDictionary(blueDoor.name, blueArea));
        doors.Add(MakeDoorDictionary(pinkDoor.name, pinkArea));
        doors.Add(MakeDoorDictionary(redDoor.name, redArea, true));
        doors.Add(MakeDoorDictionary(yellowDoor.name, yellowArea, true));

        MakeSingleton();
    }
    void Start()
    {

        List<Vector2> spawnPoints = (List<Vector2>)maps[Random.Range(0, maps.Count)]["spawnPoints"];

        foreach (Vector2 spawnPoint in spawnPoints)
        {
            ColorsManager.Instance.InstantiateColor(null, spawnPoint);
        }


    }

    void Update()
    {

    }



    public void InteractWithDoor(Collider2D door)
    {

        player.transform.position = (Vector3)FindDoorInList(door.gameObject.name)["vector"];
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

    Dictionary<string, object> MakeDoorDictionary(string name, GameObject area, bool isLeft = false, Vector3? customVector = null)
    {
        if (customVector != null) return new Dictionary<string, object>
        {
            { "name", name },
            { "vector", customVector },

        };

        GameObject door = area.transform.Find("Main Door").gameObject;

        float xValue = door.transform.position.x;

        xValue += isLeft ? -1 : 1;

        return new Dictionary<string, object>
        {
            { "name", name },
            { "vector", new Vector3(xValue, door.transform.position.y, -1f) },

        };

    }

    Dictionary<string, object> MakeMapDictionary(string name, GameObject map, List<Vector2> spawnPoints)
    {
        return new Dictionary<string, object>
        {
            { "name", name},
            { "map", map },
            { "spawnPoints", spawnPoints }
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

}
