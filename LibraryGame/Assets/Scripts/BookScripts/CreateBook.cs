using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBook : MonoBehaviour
{
    //zoveel % kans op een echt book of niet
    //daarna zoveel % kans op wat er fout is (even met birdo overleggen);

    public List<ScriptableBook> Books;

    private void Start()
    {
        ChooseNewBook();
    }

    public void ChooseNewBook()
    {
        int RandomNumber = Random.Range(0, 100);

        if(RandomNumber <= 33)
        {
            Debug.Log("BookIscorrect");

            ScriptableBook CurrentBook = Books[Random.Range(0, Books.Count)];
            GameObject.Find("Book").GetComponent<TransferBookData>().SwitchBooks(CurrentBook);
        }
        else if(RandomNumber > 33)
        {
            Debug.Log("BookIsIncorrect");

            //temp
            ScriptableBook CurrentBook = Books[Random.Range(0, Books.Count)];
            GameObject.Find("Book").GetComponent<TransferBookData>().SwitchBooks(CurrentBook);
        }
    }
}
