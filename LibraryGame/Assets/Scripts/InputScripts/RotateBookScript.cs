using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBookScript : MonoBehaviour
{
    public float RotateSpeed;
    public bool WantToRotate;
    private Vector3 FirstMousePos;
    public GameObject Book;

    private void OnMouseDown()
    {
        if (WantToRotate)
        {
            FirstMousePos = Input.mousePosition;
        }
    }

    private void OnMouseDrag()//dit werkt niet want dit moet met colliders zijn dus even een nieuwe update functie maken
    {
        Debug.Log("dasdsdsa");
        //Calculate distance between mouse first point and were it is going to;
        Vector3 MouseDelta = Input.mousePosition - FirstMousePos;

        //rotate the camera;
        float RotationX = MouseDelta.x * RotateSpeed;
        float RotationY = -MouseDelta.y * RotateSpeed;

        //rotate the object
         Book.transform.Rotate(Vector3.up, RotationY, Space.World);
        Book.transform.Rotate(Vector3.right, RotationX, Space.World);

        FirstMousePos = Input.mousePosition;
    }
}
