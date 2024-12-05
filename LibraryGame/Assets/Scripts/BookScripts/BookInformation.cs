using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInformation : MonoBehaviour
{
    public ScriptableBook RightBook;
    public GameObject CurrentBook;

    //scripts
    private ScreenInformation screenInformation;
    private BookCheckScript bookCheckScript;

    private void Start()
    { 
        screenInformation = GameObject.Find("Screen").GetComponent<ScreenInformation>();
        bookCheckScript = GameObject.Find("BookChecker").GetComponent<BookCheckScript>();
        GameObject.Find("CameraMover").GetComponent<MoveCamera>().bookAnimations = gameObject.GetComponent<BookAnimations>();
        GameObject.Find("RotateBookHandler").GetComponent<RotateBookScript>().Book = gameObject;
        GameObject.Find("CreateBook").GetComponent<CreateBook>().transferBookData = gameObject.GetComponent<TransferBookData>();
        GameObject.Find("MistakeSelecter").GetComponent<MistakeSelecter>().canvas = transform.GetChild(0).GetComponent<Canvas>();
        bookCheckScript.Book = gameObject;
        bookCheckScript.SpawnNewBook();
    }

    //share the data
    public void QrCodedScanned()
    {
        screenInformation.RightBook = RightBook;
        screenInformation.TransferData();

        bookCheckScript.CorrectBook = RightBook;
        bookCheckScript.CurrentBook = CurrentBook;

        bookCheckScript.CheckBook();
    }
}
