using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPublishDateScript : MonoBehaviour
{
    //alt = alternative;
    public List<string> TheBigManDate;
    public List<string> TheLittleManDate;

    public string MakePublicationDateUp(string PublicationDate)
    {
        string NewPublisherDate = "Fix your shit";
        if (PublicationDate == "3-11-2024")
        {
            NewPublisherDate = TheBigManDate[Random.Range(0, TheBigManDate.Count)];
        }
        else if (PublicationDate == "05-05-2004")
        {
            NewPublisherDate = TheLittleManDate[Random.Range(0, TheLittleManDate.Count)];
        }

        Debug.Log(NewPublisherDate);
        return NewPublisherDate;
    }
}
