using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStateHandler : MonoBehaviour
{
    public bool BookIsLayingDown;

    private BookCheckScript bookCheckScript;

    private void Start()
    {
        bookCheckScript = GameObject.Find("BookChecker").GetComponent<BookCheckScript>();

        BookIsLayingDown = true;
    }

    private void Update()
    {
        PickUpBook();
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
                    if (hit.transform.gameObject.GetComponent<BookAnimations>())
                    {
                        BookIsLayingDown = false;
                        StartCoroutine(bookCheckScript.PickUpBook());
                    }
                }
            }
        }
    }
}
