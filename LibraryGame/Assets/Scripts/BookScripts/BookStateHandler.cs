using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStateHandler : MonoBehaviour
{
    public bool BookIsLayingDown;
    private bool IsSwiping;
    private Vector3 StartMousePos;
    private Vector3 EndMousePos;
    private bool IsFollowingMouse;
    private GameObject Book;

    private BookCheckScript bookCheckScript;
    private BookAnimations bookAnimations;
    private MoveCamera moveCamera;
    private void Start()
    {
        bookCheckScript = GameObject.Find("BookChecker").GetComponent<BookCheckScript>();
        moveCamera = GameObject.Find("CameraMover").GetComponent<MoveCamera>();

        BookIsLayingDown = true;
    }

    private void Update()
    {
        PickUpBook();
        PutBookDown();
        FollowMouse();
    }

    public void PickUpBook()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (BookIsLayingDown)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    if (moveCamera.PosNumber == 3) //to get the book inspected;
                    {
                        if (hit.transform.gameObject.GetComponent<BookAnimations>())
                        {
                            BookIsLayingDown = false;
                            StartCoroutine(bookCheckScript.PickUpBook());
                        }
                    }
                    else//to move the book
                    {
                        Book = GameObject.Find("Book(Clone)");
                        IsFollowingMouse = true;
                    }
                }
            }
        }
    }

    //put bookdown by swiping it 

    public void PutBookDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!BookIsLayingDown)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.GetComponent<BookAnimations>())
                    {
                        IsSwiping = true;
                        bookAnimations = hit.transform.gameObject.GetComponent<BookAnimations>();
                        StartMousePos = Input.mousePosition;
                        IsSwiping = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (IsSwiping)
            {
                if (!BookIsLayingDown)
                {
                    EndMousePos = Input.mousePosition;

                    Debug.Log(StartMousePos.y - EndMousePos.y);
                    if (StartMousePos.y - EndMousePos.y > 150)//how far the player has to swipe;
                    {
                        StartCoroutine(bookAnimations.RotateBookDown(false));
                    }
                    Debug.Log(StartMousePos);
                    Debug.Log(EndMousePos);
                }   
            }
            IsSwiping = false;
        }
    }

    //hier mee bezig
    public void FollowMouse()
    {
        if (IsFollowingMouse)
        {
            // Haal de muispositie in schermcoördinaten
            Vector3 mousePosition = Input.mousePosition;

            // Zet de z-waarde op de afstand tussen de camera en het object
            mousePosition.z = Vector3.Distance(Camera.main.transform.position, Book.transform.position);

            // Converteer naar wereldcoördinaten
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Verander de x-positie van het object op basis van de verticale muisbeweging (worldPosition.y)
            Book.transform.position = new Vector3(-worldPosition.y, Book.transform.position.y, Book.transform.position.z);

            // Debug de nieuwe positie van het object
            Debug.Log($"New Book Position: {Book.transform.position}");
        }
    }
}
