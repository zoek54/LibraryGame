using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLibraryCard : MonoBehaviour
{
    private Vector3 StartLocation = new Vector3(2.44f, 0, -4.53f);
    private Vector3 NextLocation;

    private float MovingSpeed;
    private float RotationSpeed;

    private void Start()
    {
        GameObject.Find("BookChecker").GetComponent<BookCheckScript>().LibraryCard = gameObject;
    }

    public IEnumerator MoveToPlayer()
    {
        MovingSpeed = 4f;
        RotationSpeed = 400;

        StartCoroutine(IncreaseScale());

        NextLocation = new Vector3(3.47f, 1.83f, -0.243f);
        while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.1f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
            yield return null;
        }

        //rotate the right way;
        Vector3 EndRotation = gameObject.transform.localEulerAngles;
        EndRotation = new Vector3(EndRotation.x, EndRotation.y, 0);

        while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.1f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator IncreaseScale()
    {
        Vector3 BigScale = new Vector3(0.02f, 0.4f, 0.7f);
        float ScallingSpeed = 2f;

        while (Vector3.Distance(gameObject.transform.localScale, BigScale) > 0.1f)
        {
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.localScale, BigScale, ScallingSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator MoveBack()
    {
        MovingSpeed = 4f;
        RotationSpeed = 600;

        StartCoroutine(DecreaseScale());

        NextLocation = new Vector3(4.064f, 1.07f, -0.769f);

        while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.01f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
            yield return null;
        }

        //rotate the right way;
        Vector3 EndRotation = gameObject.transform.localEulerAngles;
        EndRotation = new Vector3(EndRotation.x, EndRotation.y, 90);

        while (Vector3.Distance(gameObject.transform.localEulerAngles, EndRotation) > 0.01f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, EndRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        MovingSpeed = 0.25f;
        NextLocation = new Vector3(4.064f, 1f, -0.769f);

        while (Vector3.Distance(gameObject.transform.position, NextLocation) > 0.01f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, NextLocation, MovingSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator DecreaseScale()
    {
        Vector3 BigScale = new Vector3(0.02f, 0.16f, 0.28f);
        float ScallingSpeed = 2f;

        while (Vector3.Distance(gameObject.transform.localScale, BigScale) > 0.01f)
        {
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.localScale, BigScale, ScallingSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
