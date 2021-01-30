using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public Buff buffObj;
    public static BuffManager instance { get; set; }
    public List<Dictionary<string, object>> buffs = new List<Dictionary<string, object>>();


    private void Awake()
    {
        buffs.Add(MakeBuffDictionary("IncreaseAttack", 1));
        buffs.Add(MakeBuffDictionary("IncreaseMovement", 3));
        buffs.Add(MakeBuffDictionary("IncreaseRange", 1));
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


    private Dictionary<string, object> MakeBuffDictionary(string name, int effect)
    {
        return new Dictionary<string, object>
        {
            { "name", name },
            { "effect", effect }

        };
    }

    public Dictionary<string, object> ChooseRandomBuff()
    {
        return buffs[Random.Range(0, buffs.Count)];

    }

    public void InstantiateBuff(Player player , string name = null )
    {
        Buff buff = Instantiate(buffObj);



        buff.transform.position = player.transform.position;



        if (name != null)
        {
            if (FindBuffInList(name) != null)
            {
                // Add buff to players buff list

            }
            else
            {
                Debug.Log($"{name} Buff not found");
            }
        }
        else
        {
            // Add random buff to player buff list;
        }



    }


    public Dictionary<string, object> FindBuffInList(string name)
    {
        foreach (Dictionary<string, object> buff in buffs)
        {
            if ((string)buff["name"] == name)

            {
                return buff;
            }
        }
        return null;
    }
}
