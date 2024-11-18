using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInformation : MonoBehaviour
{
    public ScriptableBook RightBook;

    //scripts
    private ScreenInformation screenInformation;

    private void Start()
    {
        screenInformation = GameObject.Find("Screen").GetComponent<ScreenInformation>();
    }

    public void QrCodedScanned()
    {
        screenInformation.RightBook = RightBook;
        screenInformation.TransferData();
    }
}
