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
