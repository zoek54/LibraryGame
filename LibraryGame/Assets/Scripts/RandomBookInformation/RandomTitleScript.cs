using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTitleScript : MonoBehaviour
{
    //alt = alternative;
    public List<string> TheBigManAlt;
    public List<string> TheLittlemanAlt;

    public string MakeTitleUp(string Title)
    {
        string NewTitle = "Fix your shit";
        if (Title == "The big man")
        {
            NewTitle = TheBigManAlt[Random.Range(0, TheBigManAlt.Count)];
        }
        else if (Title == "The little man")
        {
            NewTitle = TheLittlemanAlt[Random.Range(0, TheLittlemanAlt.Count)];
        }

        Debug.Log(NewTitle);
        return NewTitle;
    }
}
