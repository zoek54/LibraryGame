using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private Vector3 StartLocation = new Vector3(2.44f, 0, -4.53f);
    private Vector3 NextLocation;

    private float MovingSpeed;
    private float RotationSpeed;

    public GameObject LibraryCard;
    public GameObject Book;

    private BookCheckScript BookCheckScript;
    private void Start()
    {
        BookCheckScript = GameObject.Find("BookChecker").GetComponent<BookCheckScript>();
        StartCoroutine(MoveToPlayer());
    }

    public IEnumerator MoveToPlayer()
    {
        BookCheckScript.AliveCharacter = gameObject;
        NextLocation = new Vector3(2.44f, 0, -0.21f);

        MovingSpeed = 4f;
        RotationSpeed = 400;

        while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
            yield return null;
        }

        //rotate the right way;
        Vector3 EndRotation = gameObject.transform.localEulerAngles;
        EndRotation = new Vector3(EndRotation.x, 90, EndRotation.z);

        while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        //oldpath
        //NextLocation = new Vector3(-0.86f, 0, -0.13f);

        //while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        //{
        //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
        //    yield return null;
        //}

        ////rotate the right way;
        //EndRotation = new Vector3(EndRotation.x, 90, EndRotation.z);

        //while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        //{
        //    gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
        //    yield return null;
        //}

        //NextLocation = new Vector3(2.22f, 0, -0.13f);

        //while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        //{
        //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
        //    yield return null;
        //}


        GameObject SpawnendLibraryCard = Instantiate(LibraryCard);
        SpawnendLibraryCard.transform.position = new Vector3(2.56f, 1.15f, -0.31f);
        StartCoroutine(SpawnendLibraryCard.GetComponent<MoveLibraryCard>().MoveBack());
        yield return new WaitForSeconds(0.3f);

        GameObject SpawnendBook = Instantiate(Book);
        SpawnendBook.transform.position = new Vector3(2.56f, 1.15f, -0.31f);
        StartCoroutine(SpawnendBook.GetComponent<BookAnimations>().MoveToPlayer(new Vector3(3.79f, 1.02f, -0.24f)));
    }

    public IEnumerator MoveToExit()
    {
        MovingSpeed = 4f;
        RotationSpeed = 400;

        //rotate the right way;
        Vector3 EndRotation = gameObject.transform.localEulerAngles;
        EndRotation = new Vector3(EndRotation.x, 0, EndRotation.z);

        while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        NextLocation = new Vector3(2.44f, 0, 4.61f);

        while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
            yield return null;
        }

        //old path
        ////rotate the right way;
        //EndRotation = new Vector3(EndRotation.x, 180, EndRotation.z);

        //while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        //{
        //    gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
        //    yield return null;
        //}

        //NextLocation = new Vector3(-0.86f, 0, -3.7f);

        //while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        //{
        //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
        //    yield return null;
        //}

        //EndRotation = new Vector3(EndRotation.x, 270, EndRotation.z);

        //while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        //{
        //    gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
        //    yield return null;
        //}

        //NextLocation = new Vector3(-4.26f, 0, -3.7f);

        //while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        //{
        //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
        //    yield return null;
        //}

        BookCheckScript.NewCharacter();
        Destroy(gameObject);
    }
}
