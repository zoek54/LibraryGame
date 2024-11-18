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
    public TextMeshProUGUI Publisher;
    public TextMeshProUGUI DueDate;
    //this one we do when we have art;
    private Sprite FrontCover;
    private Sprite BackCover;

    public void SwitchBooks(ScriptableBook CurrentBook)
    {
        int RandomNumber = Random.Range(0, Books.Count);

        Name.text = CurrentBook.Name;
        Author.text = CurrentBook.Author;
        PublicationDate.text = CurrentBook.PublicationDate;
        Publisher.text = CurrentBook.Publisher;
        DueDate.text = "Due date: " + CurrentBook.DueDate;

        //temp to make a wrong author
        Author.text = GameObject.Find("RandomAuthor").GetComponent<RandomAuthorScript>().MakeAuthorUp(CurrentBook.Author);

        gameObject.GetComponent<BookInformation>().RightBook = CurrentBook;
    }
}
