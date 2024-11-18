using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenInformation : MonoBehaviour
{
    public ScriptableBook RightBook;

    public void TransferData()
    {
        string Title = RightBook.Name;
        string Author = RightBook.Author;
        string PublicationDate = RightBook.PublicationDate;
        string DueDate = RightBook.DueDate;
        string Publisher = RightBook.Publisher;

        string EndText = " Title: " + Title + "<br> Author: " + Author + "<br> Publisher: " + Publisher + "<br> Publish date: " + PublicationDate + "<br> Due date: " + DueDate;

        TextMeshProUGUI ScreenText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ScreenText.text = EndText;
    }
}