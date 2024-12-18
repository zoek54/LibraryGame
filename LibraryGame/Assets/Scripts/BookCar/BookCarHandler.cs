using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCarHandler : MonoBehaviour
{
    //all world vectors
    private Vector3 Spot1 = new Vector3(4.8f, 0.98f, 1.77f);
    private Vector3 Spot2 = new Vector3(5.4f, 0.98f, 1.77f);
    private Vector3 Spot3 = new Vector3(4.8f, 1.037f, 1.77f);
    private Vector3 Spot4 = new Vector3(5.4f, 1.037f, 1.77f);
    private Vector3 Spot5 = new Vector3(5.2f, 1.076f, 1.77f);

    public bool Spot1IsFull;
    public bool Spot2IsFull;
    public bool Spot3IsFull;
    public bool Spot4IsFull;
    public bool Spot5IsFull;

    public float RotateAmount;
    public List<GameObject> BooksOnCar;

    public Vector3 ChooseNewSpot()
    {
        if (!Spot1IsFull)
        {
            Debug.Log("11");
            Spot1IsFull = true;
            RotateAmount = 359;
            return Spot1;
        }
        else if (!Spot2IsFull)
        {
            Debug.Log("12");
            Spot2IsFull = true;
            RotateAmount = 359;
            return (Spot2);
        }
        else if (!Spot3IsFull)
        {
            Spot3IsFull = true;
            RotateAmount = 359;
            return (Spot3);
        }
        else if (!Spot4IsFull)
        {
            Spot4IsFull = true;
            RotateAmount = 359;
            return (Spot4);
        }
        else if (!Spot5IsFull)
        {
            Spot5IsFull = true;
            RotateAmount = 270;
            StartCoroutine(ClearBooks());
            return (Spot5);
        }
        else
        {
            Debug.Log("All spots are full noob");
            RotateAmount = 270;
            return new Vector3(0, 0, 0);
        }
    }

    public IEnumerator ClearBooks()
    {
        yield return new WaitForSeconds(5f);

        Spot1IsFull = false;
        Spot2IsFull = false;
        Spot3IsFull = false;
        Spot4IsFull = false;
        Spot5IsFull = false;

        foreach(GameObject Books in BooksOnCar)
        {
            Destroy(Books);
        }

        BooksOnCar.Clear();
    }
}
