using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour
{

    public ColorObj colorObject;
    public static ColorsManager Instance { get; set; }
    public List<Dictionary<string, string>> colors = new List<Dictionary<string, string>>();


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
        colors.Add(MakeColorDictionary("Blue", "#4362b5", "Slow"));
        colors.Add(MakeColorDictionary("Yellow", "#edb135", "Range"));
        colors.Add(MakeColorDictionary("Red", "#dc4933", "FireBall"));
        colors.Add(MakeColorDictionary("Green", "#70d888", "Shield"));
        MakeSingleton();
    }


    public void InstantiateColor(string name = null, Vector2 position = new Vector2())
    {
        ColorObj color = Instantiate(colorObject);
        color.transform.position = position;

        if (name != null)
        {
            Dictionary<string, string> values = FindColorInList(name);

            if (values != null)
            {
                color.color = values;
            }
            else
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

    public Dictionary<string, string> ChooseRandomColor()
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

}
