using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New book", menuName = "New book")]
public class ScriptableBook : ScriptableObject
{
    public string Name;
    public string Author;
    public string PublicationDate;
    public string Publisher;
    public string DueDate;
    public Sprite FrontCover;
    public Sprite BackCover;
}
