using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Dict

    public Dictionary<string, AreasStruct> doorsDict = new Dictionary<string, AreasStruct>();

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

        AreasStruct areaStruct = doorsDict[door.gameObject.name];


        player.transform.position = areaStruct.customCoords;

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

        doorsDict.Add(mainDoor.name, MakeStruct(mainArea, false, new Vector3(-0.17f, -5.84f, -1f)));
        doorsDict.Add(blueDoor.name, MakeStruct(blueArea));
        doorsDict.Add(redDoor.name, MakeStruct(redArea, true));
        doorsDict.Add(yellowDoor.name, MakeStruct(yellowArea, true));
        doorsDict.Add(pinkDoor.name, MakeStruct(pinkArea));
        doorsDict.Add(bossDoor.name, MakeStruct(bossArea, false, new Vector3(0, 35f, -1f)));
    }

    AreasStruct MakeStruct(GameObject area, bool isLeft = false, Vector3? customVector = null)
    {

        if (customVector != null) return new AreasStruct(area, (Vector3)customVector);


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


        return new AreasStruct(area, new Vector3(xValue, door.transform.position.y, -1f));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
