using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDueDateScript : MonoBehaviour
{
    //alt = alternative;
    public List<string> TheBigManDueDate;
    public List<string> TheLittleManDueDate;

    public string MakeDueDateUp(string DueDate)
    {
        string NewDueDate = "Fix your shit";
        if (DueDate == "Due date: 18-11-2024")
        {
            NewDueDate = TheBigManDueDate[Random.Range(0, TheBigManDueDate.Count)];
        }
        else if (DueDate == "Due date: 32-12-2024")
        {
            NewDueDate = TheLittleManDueDate[Random.Range(0, TheLittleManDueDate.Count)];
        }

        return NewDueDate;
    }
}
