using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStateHandler : MonoBehaviour
{
    public bool BookIsLayingDown;
    private bool IsSwiping;
    private Vector3 StartMousePos;
    private Vector3 EndMousePos;
    private GameObject Book;
    public bool WantsToMoveTheBook;

    private BookCheckScript bookCheckScript;
    private BookAnimations bookAnimations;
    private MoveCamera moveCamera;
    private BookCarHandler bookCarHandler;
    private void Start()
    {
        bookCheckScript = GameObject.Find("BookChecker").GetComponent<BookCheckScript>();
        moveCamera = GameObject.Find("CameraMover").GetComponent<MoveCamera>();
        bookCarHandler = GameObject.Find("BookCar").GetComponent<BookCarHandler>();

        BookIsLayingDown = true;
    }

    private void Update()
    {
        PickUpBook();
        PutBookDown();
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
                            moveCamera.IsPlayingAnimation = true;
                            BookIsLayingDown = false;
                            StartCoroutine(bookCheckScript.PickUpBook());
                        }
                    }
                    if (hit.transform.gameObject.tag == "BookCar")
                    {
                        if (WantsToMoveTheBook)
                        {
                            StartCoroutine(MoveBookToCar());
                            WantsToMoveTheBook = false;
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (BookIsLayingDown)
                {
                    if (moveCamera.PosNumber != 3)
                    {
                        if (hit.transform.gameObject.GetComponent<BookAnimations>())
                        {
                            Book = hit.transform.gameObject;
                            WantsToMoveTheBook = true;
                        }
                        else
                        {
                            WantsToMoveTheBook = false;
                        }
                    }
                    else
                    {
                        WantsToMoveTheBook = false;
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
                }   
            }
            IsSwiping = false;
        }
    }

    public IEnumerator MoveBookToCar()
    {
        float Speed = 2f;

        while (Vector3.Distance(Book.transform.position, new Vector3(4.9f, 1f, -0.25f)) > 0.1f)
        {
            Book.transform.position = Vector3.MoveTowards(Book.transform.position, new Vector3(4.9f, 1f, -0.25f), Speed * Time.deltaTime);
            yield return null;
        }

        Vector3 ChosenSpot = bookCarHandler.ChooseNewSpot();

        StartCoroutine(RotateBook());
        while (Vector3.Distance(Book.transform.position, ChosenSpot) > 0.1f)
        {
            Book.transform.position = Vector3.MoveTowards(Book.transform.position, ChosenSpot, Speed * Time.deltaTime);
            yield return null;
        }

        bookCarHandler.BooksOnCar.Add(Book);
        StartCoroutine(bookCheckScript.HideBook());
    }

    public IEnumerator RotateBook()
    {
        //rotating
        float Speed = 90f;

        while (Vector3.Distance(Book.transform.localEulerAngles, new Vector3(Book.transform.localEulerAngles.x, bookCarHandler.RotateAmount, Book.transform.localEulerAngles.z)) > 1f)
        {
            Book.transform.localEulerAngles = Vector3.MoveTowards(Book.transform.localEulerAngles, new Vector3(Book.transform.localEulerAngles.x, bookCarHandler.RotateAmount, Book.transform.localEulerAngles.z), Speed * Time.deltaTime);
            yield return null;
        }
    }
}
