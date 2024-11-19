using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPublisherScript : MonoBehaviour
{
    //alt = alternative;
    public List<string> TheWeirdPublisherAlt;
    public List<string> ThePolarbears;

    public string MakePublisherUp(string Publisher)
    {
        string NewPublisher = "Fix your shit";
        if (Publisher == "The weird publisher")
        {
            NewPublisher = TheWeirdPublisherAlt[Random.Range(0, TheWeirdPublisherAlt.Count)];
        }
        else if (Publisher == "The Polarbears")
        {
            NewPublisher = ThePolarbears[Random.Range(0, ThePolarbears.Count)];
        }

        return NewPublisher;
    }
}
