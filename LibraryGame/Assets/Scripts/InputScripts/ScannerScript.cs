using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{
    public float RayDistance = 10f;
    public bool IsFollowingMouse;
    private GameObject Light;

    private void Start()
    {
        Light = GameObject.Find("ScannerLight");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && IsFollowingMouse)
        {
            Light.SetActive(false);
            IsFollowingMouse = false;
        }

        PickUpScanner();
        RaycastFromScanner();
        FollowMouse();
    }

    public void PickUpScanner()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<ScannerScript>())
                {
                    Light.SetActive(true);
                    IsFollowingMouse = true;
                }
            }
        }
    }

    public void RaycastFromScanner()
    {
        // Perform the raycast
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, RayDistance))
        {
            if(hit.transform.gameObject.tag == "QrCode")
            {
                hit.transform.parent.GetComponent<BookInformation>().QrCodedScanned();
            }
        }

        Debug.DrawRay(transform.position, transform.forward * RayDistance, Color.red);
    }

    public void FollowMouse()
    {
        if (IsFollowingMouse)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;
        }
    }
}
