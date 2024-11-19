using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBookScript : MonoBehaviour
{
    [Header("Customisable variables")]
    public float RotateSpeed;

    [Header("Information")]
    public bool WantToRotate;

    [Header("Script logic")]
    private Vector3 FirstMousePos;
    private GameObject Book;
    private bool MouseButtonIsDown;

    [Header("Refrences")]
    private ScannerScript scannerScript;

    private void Start()
    {
        Book = GameObject.Find("Book").gameObject;
        scannerScript = GameObject.Find("Scanner").GetComponent<ScannerScript>();
    }

    private void Update()
    {
        if (WantToRotate)
        {
            SetMousePos();
            RotateBook();
        }   
    }

    public void SetMousePos()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            FirstMousePos = Input.mousePosition;
            MouseButtonIsDown = true;
        }
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            MouseButtonIsDown = false;
        }
    }

    public void RotateBook()
    {
        if (MouseButtonIsDown && !scannerScript.IsFollowingMouse)
        {
            //Calculate distance between mouse first point and were it is going to;
            Vector3 MouseDelta = Input.mousePosition - FirstMousePos;

            //rotate the camera;
            float RotationX = MouseDelta.x * RotateSpeed;
            //float RotationY = -MouseDelta.y * RotateSpeed;

            //rotate the object
            //Book.transform.Rotate(Vector3.up, RotationY, Space.World);
            Book.transform.Rotate(-Vector3.up, RotationX *Time.deltaTime, Space.World);

            FirstMousePos = Input.mousePosition;
        }
    }
}
