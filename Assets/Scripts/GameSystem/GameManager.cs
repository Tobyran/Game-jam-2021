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

    // Main Camera
    public CameraController mainCamera;

    // Player
    public Player player;
    private Player currentPlayer = null;
    private PlayerHealth currentplayerHealth;
    
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

    // Panes
    public GameObject menuPane;
    public GameObject loadingPane;
    public GameObject playPane;
    public GameObject pausedPane;
    public GameObject gameOverPane;

    // Texts
    public Text score;
    public Text lifes;
    public Text door;

    // Enemies
    public EnemyController enemy;
    private EnemyController currEnemy;

    // Game Variables

    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value; score.text = $"SCORE: {value}"; }
    }

    private int _lifes;

    public int Lifes
    {
        get { return _lifes; }
        set { _lifes = value; lifes.text = $"LIFES: {value}"; }
    }


    public static GameManager Instance { get; set; }

    public enum State { MENU, INIT, LOADING, PLAY, PAUSE, GAMEOVER };

    private State oldState;

    public State CurrentState { get { return CurrentState; } }

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

        // Toby - Cambiar a State.INIT para evitar tener que darle click cada rato al boton del menu.

        SwitchState(State.MENU);

    }

    void Update()
    {
        switch (oldState)
        {

            case State.PLAY:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Pause();
                }
                break;
            case State.PAUSE:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Resume();
                }
                break;
            case State.GAMEOVER:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SwitchState(State.MENU);
                }
                break;
        }
    }

    public void Play()
    {
        SwitchState(State.INIT);
    }

    void Pause()
    {
        SwitchState(State.PAUSE);
    }

    void Resume()
    {
        SwitchState(State.PLAY);
    }

    public void PlayerIsDead()
    {
        SwitchState(State.GAMEOVER);
    }

    void SwitchState(State newState, float delay = 0f)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        yield return new WaitForSeconds(delay);
        EndState();
        oldState = newState;
        StartState(newState);

    }

    void StartState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                menuPane.SetActive(true);
                break;
            case State.INIT:
                SetDefaultValues();
                loadingPane.SetActive(true);
                SwitchState(State.LOADING);
                break;
            case State.LOADING:
                CreatePlayer();
                CreateEnemy();
                ConfigureScene();

                // Toby - Se puede reducir el delay a 0 para que la carga sea basicamente inmediata.

                SwitchState(State.PLAY, 3f);
                break;
            case State.PLAY:
                Time.timeScale = 1;
                playPane.SetActive(true);
                break;
            case State.PAUSE:
                Time.timeScale = 0;
                pausedPane.SetActive(true);
                break;
            case State.GAMEOVER:

                if (currentplayerHealth.lifes <= 0)
                {
                    Destroy(currentPlayer.gameObject);
                    gameOverPane.SetActive(true);
                }
                break;
        }
    }

    void EndState()
    {
        switch (oldState)
        {
            case State.MENU:
                menuPane.SetActive(false);
                break;
            case State.LOADING:
                loadingPane.SetActive(false);
                break;
            case State.PLAY:
                playPane.SetActive(false);
                break;
            case State.PAUSE:
                pausedPane.SetActive(false);
                break;
            case State.GAMEOVER:
                gameOverPane.SetActive(false);
                break;
        }

    }

    void CreatePlayer()
    {
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(player, new Vector2(-0.17f, -5.84f), Quaternion.identity);           
            currentplayerHealth = currentPlayer.GetComponent<PlayerHealth>();
        }
       
        mainCamera.player = currentPlayer.gameObject;
    }

    void CreateEnemy()
    {
        if (currEnemy == null)
        {
            currEnemy = Instantiate(enemy, new Vector2(-4.01f, 6.34f), Quaternion.identity);
            currentplayerHealth = currEnemy.GetComponent<PlayerHealth>();
        }
        else
        {
            currEnemy.transform.position = new Vector2(-4.01f, 6.34f);
        }
        currEnemy.lifes = 3;
        currEnemy.player = currentPlayer.transform;
    }

    void SetDefaultValues()
    {
        Score = 0;
        Lifes = 3;
    }

    void ConfigureScene()
    {

        List<Vector2> spawnPoints = (List<Vector2>)maps[Random.Range(0, maps.Count)]["spawnPoints"];

        foreach (Vector2 spawnPoint in spawnPoints)
        {
            ColorsManager.Instance.InstantiateColor(null, spawnPoint);
        }
    }

    public void InteractWithDoor(Collider2D door)
    {

        currentPlayer.transform.position = (Vector2)FindDoorInList(door.gameObject.name)["vector"];
    }

    public void ShowDoorMessage(Collider2D doorCollider, bool isStaying)
    {
        if (isStaying)
        {
            door.text = $"Press E to interact with: {doorCollider.name}";
        }
        else
        {
            door.text = "";
        }


    }

    Dictionary<string, object> MakeDoorDictionary(string name, GameObject area, bool isLeft = false, Vector2? customVector = null)
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
            { "vector", new Vector2(xValue, door.transform.position.y) },

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
