using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour
{
 
    public ColorObj colorObject;
    public static ColorsManager instance;
    public List<Dictionary<string, string>> colors = new List<Dictionary<string, string>>();




    private void Awake()
    {
        colors.Add(MakeColorDictionary("Blue", "#4A52F2", "MovSpeedIncrease"));
        colors.Add(MakeColorDictionary("Red", "#EC4947", "AttackIncrease"));
        colors.Add(MakeColorDictionary("Yellow", "#DEF026", "IncreaseLifes"));
        colors.Add(MakeColorDictionary("Pink", "#C33EF2", "LifeSteal"));
      
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


    public void InstantiateColor(string name = null, Vector3 position = new Vector3())
    {
        ColorObj color = Instantiate(colorObject);
        color.transform.position = position;

        if (name != null)
        {
            if (FindColorInList(name) != null) {
                color.color = FindColorInList(name);

            } else
            {
                Debug.Log($"{name} Color not found");
            }
        }
        else
        {
            color.color = ChooseRandomColor();
        }

       

    }

    Dictionary<string, string> MakeColorDictionary(string name, string value, string effect)
    {
        return new Dictionary<string, string>
        {
            { "name", name },
            { "value", value },
            { "effect", effect }
        };

    }

    public Dictionary<string,string> ChooseRandomColor()
    {

        return colors[Random.Range(0, colors.Count)];

    }

    public Dictionary<string, string> FindColorInList(string name)
    {
        foreach (Dictionary<string, string> color in colors)
        {
            if (color["name"] == name)

            {
                return color;
            }
        }
        return null;
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
