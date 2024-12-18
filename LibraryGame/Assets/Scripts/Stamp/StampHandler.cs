using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampHandler : MonoBehaviour
{
    public bool IsFollowingMouse;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && IsFollowingMouse)
        {
            IsFollowingMouse = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        PickUpStamp();
        FollowMouse();
    }

    public void PickUpStamp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<StampHandler>())
                {
                    IsFollowingMouse = true;
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
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
