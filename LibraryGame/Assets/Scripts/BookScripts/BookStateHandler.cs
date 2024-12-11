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
            Debug.Log(Input.mousePosition);
            Vector3 mousePosition = new Vector3(0,0,0);
            mousePosition.z = mousePosition.z += 3;
            //mousePosition.y = mousePosition.x;
            mousePosition.x = Input.mousePosition.y;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Book.transform.position = worldPosition;
        }
    }
}
