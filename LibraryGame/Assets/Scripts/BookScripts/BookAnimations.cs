using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimations : MonoBehaviour
{
    private Vector3 EndPos = new Vector3(0,0,0);
    private Vector3 EndRotation = new Vector3(0, 0, 0);

    private Vector3 OriginalPos;
    private Vector3 originalRotation;

    private float MovingSpeed;
    public float RotationSpeed;

    //scripts
    private MoveCamera moveCamera;

    private void Start()
    {
        OriginalPos = gameObject.transform.position;
        originalRotation = gameObject.transform.localEulerAngles;

        moveCamera = GameObject.Find("CameraMover").GetComponent<MoveCamera>();
    }

    public IEnumerator PickBookUp()
    {
        MovingSpeed = 0.8f;
        EndPos = gameObject.transform.position;
        EndPos = new Vector3(EndPos.x, EndPos.y + 0.8f, EndPos.z);

        while (Vector3.Distance(gameObject.transform.position, EndPos) > 0.1f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPos, MovingSpeed * Time.deltaTime);
            yield return null;
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
        MovingSpeed = 0.5f;
        while (Vector3.Distance(gameObject.transform.position, OriginalPos) > 0.01f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, OriginalPos, MovingSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator RotateBookDown()
    {
        Vector3 FixedRotation = new Vector3(gameObject.transform.eulerAngles.x, originalRotation.y, gameObject.transform.eulerAngles.z);
        float FixRotationSpeed = 400f;

        while (Vector3.Distance(gameObject.transform.localEulerAngles, FixedRotation) > 0.01f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, FixedRotation, FixRotationSpeed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(LayDownBook());

        while (Vector3.Distance(gameObject.transform.localEulerAngles, originalRotation) > 0.1f)
        {
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(gameObject.transform.localEulerAngles, originalRotation, RotationSpeed * Time.deltaTime);
            yield return null;
        }

        moveCamera.IsPlayingAnimation = false;
    }
}
