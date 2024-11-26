using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCheckScript : MonoBehaviour
{
    public ScriptableBook CorrectBook;
    public GameObject CurrentBook;

    //check elke diffrences of er een verschil is als er een verschil check of deze bool het zelfde is dan de gene die geselecteerd zijn met nog meer bools

    public void CheckBook()
    {
        TransferBookData transferBookData = CurrentBook.GetComponent<TransferBookData>();

        if (CorrectBook.Name == transferBookData.Name.text.ToString())
        {
            Debug.Log("das");
        }
        if (CorrectBook.Author == transferBookData.Author.text.ToString())
        {
            Debug.Log("das1");
        }
        if (CorrectBook.Publisher == transferBookData.Publisher.text.ToString())
        {
            Debug.Log("das2");
        }
        if (CorrectBook.PublicationDate == transferBookData.PublicationDate.text.ToString())
        {
            Debug.Log("das3");
        }
        if (CorrectBook.DueDate == transferBookData.DueDate.text.ToString())
        {
            Debug.Log("das4");
        }
    }
}
