using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimations : MonoBehaviour
{
    private Vector3 EndPos = new Vector3(0,0,0);
    private Vector3 EndRotation = new Vector3(0, 0, 0);

    private Vector3 OriginalPos = new Vector3(3.7f, 1.02f, -0.24f);
    private Vector3 originalRotation;

    private float MovingSpeed;
    public float RotationSpeed;

    //scripts
    private MoveCamera moveCamera;
    private MoveLibraryCard moveLibraryCard;
    private BookStateHandler bookStateHandler;

    private void Start()
    {
        originalRotation = gameObject.transform.localEulerAngles;

        moveCamera = GameObject.Find("CameraMover").GetComponent<MoveCamera>();
        moveLibraryCard = GameObject.Find("LibraryCard(Clone)").GetComponent<MoveLibraryCard>();
        bookStateHandler = GameObject.Find("BookStateHandler").GetComponent<BookStateHandler>();
    }

    public IEnumerator PickBookUp()
    {
        if (!moveLibraryCard.CardIsBeingInspected)
        {
            StartCoroutine(RotateBookUp());
            MovingSpeed = 0.8f;
            EndPos = gameObject.transform.position;
            EndPos = new Vector3(EndPos.x, EndPos.y + 0.8f, EndPos.z);

            while (Vector3.Distance(gameObject.transform.position, EndPos) > 0.1f)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPos, MovingSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    public IEnumerator RotateBookUp()
    {
        EndRotation = gameObject.transform.localEulerAngles;
        EndRotation = new Vector3(0, EndRotation.y, EndRotation.z);

        while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        moveCamera.IsPlayingAnimation = false;
    }

    public IEnumerator LayDownBook()
    {
        MovingSpeed = 1f;
        while (Vector3.Distance(gameObject.transform.position, OriginalPos) > 0.01f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, OriginalPos, MovingSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator RotateBookDown(bool WantToMoveToNpc)
    {
        Vector3 FixedRotation = new Vector3(gameObject.transform.eulerAngles.x, originalRotation.y, gameObject.transform.eulerAngles.z);
        float FixRotationSpeed = 400f;

        while (Vector3.Distance(gameObject.transform.localEulerAngles, FixedRotation) > 0.01f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, FixedRotation, FixRotationSpeed * Time.deltaTime);
            yield return null;
        }

        if (WantToMoveToNpc)
        {
            StartCoroutine(MoveToNpc());
        }
        else
        {
            StartCoroutine(LayDownBook());
        }

        while (Vector3.Distance(gameObject.transform.localEulerAngles, originalRotation) > 0.1f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, originalRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        moveCamera.IsPlayingAnimation = false;
        bookStateHandler.BookIsLayingDown = true;
    }

    public IEnumerator MoveToPlayer(Vector3 Location)
    {
        float MovementSpeed = 4;
        while (Vector3.Distance(gameObject.transform.position, Location) > 0.1f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Location, MovementSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator MoveToNpc()
    {
        float MovementSpeed = 1;
        while (Vector3.Distance(gameObject.transform.position, new Vector3(2.56f, 1.15f, -0.31f)) > 0.01f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(2.56f, 1.15f, -0.31f), MovementSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
