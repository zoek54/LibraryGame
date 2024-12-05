using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCardHandler : MonoBehaviour
{
    private void Update()
    {
        PickUpLibraryCard();
    }

    public void PickUpLibraryCard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<MoveLibraryCard>())
                {
                    StartCoroutine(hit.transform.gameObject.GetComponent<MoveLibraryCard>().MoveToPlayer());
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<MoveLibraryCard>())
                {
                    StartCoroutine(hit.transform.gameObject.GetComponent<MoveLibraryCard>().MoveBack());
                }
            }
        }
    }
}
