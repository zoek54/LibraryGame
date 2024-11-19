using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransferBookData : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Author;
    public TextMeshProUGUI PublicationDate;
    public TextMeshProUGUI Publisher;
    public TextMeshProUGUI DueDate;
    //this one we do when we have art;
    private Sprite FrontCover;
    private Sprite BackCover;

    public ScriptableBook CorrectBook;

    public void SwitchBooks(ScriptableBook CurrentBook)
    {
        Name.text = CurrentBook.Name;
        Author.text = CurrentBook.Author;
        PublicationDate.text = CurrentBook.PublicationDate;
        Publisher.text = CurrentBook.Publisher;
        DueDate.text = "Due date: " + CurrentBook.DueDate;

        gameObject.GetComponent<BookInformation>().RightBook = CorrectBook;
    }
}
