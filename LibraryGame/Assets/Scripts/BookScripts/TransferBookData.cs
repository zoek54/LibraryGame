using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransferBookData : MonoBehaviour
{
    public List<ScriptableBook> Books;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Author;
    public TextMeshProUGUI PublicationDate;
    //this one we do when we have art;
    private Sprite FrontCover;
    private Sprite BackCover;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchBooks();
        }
    }

    public void SwitchBooks()
    {
        int RandomNumber = Random.Range(0, Books.Count);

        ScriptableBook CurrentBook = Books[RandomNumber];

        Name.text = CurrentBook.Name;
        Author.text = CurrentBook.Author;
        PublicationDate.text = CurrentBook.PublicationDate;
    }
}
