using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAuthorScript : MonoBehaviour
{
    //alt = alternative;
    public List<string> HankCoolGuyAlt;
    public List<string> DaveCoolGuyAlt;

    public string MakeAuthorUp(string Author)
    {
        string NewAuthor = "Fix your shit";
        if(Author == "Hank cool guy")
        {
            NewAuthor = HankCoolGuyAlt[Random.Range(0, HankCoolGuyAlt.Count)];
        }
        else if(Author == "Dave sad guy")
        {
            NewAuthor = DaveCoolGuyAlt[Random.Range(0, HankCoolGuyAlt.Count)];
        }

        Debug.Log(NewAuthor);
        return NewAuthor;
    }
}
