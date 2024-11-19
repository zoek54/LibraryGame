using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MistakeSelecter : MonoBehaviour
{
    [SerializeField] private Canvas canvas; // Verwijzing naar de Canvas (belangrijk voor de GraphicRaycaster)
    public GameObject Circle;

    void Update()
    {
        DrawCircle();
        RemoveCircle();
    }

    public void DrawCircle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition = Input.mousePosition;

            // List for results;
            PointerEventData PointerEventData = new PointerEventData(EventSystem.current);
            PointerEventData.position = MousePosition;

            GraphicRaycaster Raycaster = canvas.GetComponent<GraphicRaycaster>();

            var Results = new System.Collections.Generic.List<RaycastResult>();
            Raycaster.Raycast(PointerEventData, Results);

            // Loop door de resultaten
            foreach (var result in Results)
            {               
                if (result.gameObject.name == "Title")//clicked Title
                {
                    if (result.gameObject.transform.childCount == 0)
                    {
                        GameObject SpawnendCircle = Instantiate(Circle, result.gameObject.transform);
                        SpawnendCircle.transform.position = result.gameObject.transform.position;
                    }
                }
                else if (result.gameObject.name == "Author")//clicked Author
                {
                    if (result.gameObject.transform.childCount == 0)
                    {
                        GameObject SpawnendCircle = Instantiate(Circle, result.gameObject.transform);
                        SpawnendCircle.transform.position = result.gameObject.transform.position;
                    }
                }
                else if (result.gameObject.name == "PublicationDate")//clicked publication date
                {
                    if (result.gameObject.transform.childCount == 0)
                    {
                        GameObject SpawnendCircle = Instantiate(Circle, result.gameObject.transform);
                        SpawnendCircle.transform.position = result.gameObject.transform.position;
                    }
                }
                else if (result.gameObject.name == "Publisher")//clicked Publisher
                {
                    if (result.gameObject.transform.childCount == 0)
                    {
                        GameObject SpawnendCircle = Instantiate(Circle, result.gameObject.transform);
                        SpawnendCircle.transform.position = result.gameObject.transform.position;
                    }
                }
                else if (result.gameObject.name == "Due date")//clicked due date
                {
                    if (result.gameObject.transform.childCount == 0)
                    {
                        GameObject SpawnendCircle = Instantiate(Circle, result.gameObject.transform);
                        SpawnendCircle.transform.position = result.gameObject.transform.position;
                    }
                }
            }
        }
    }

    public void RemoveCircle()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 MousePosition = Input.mousePosition;

            // List for results;
            PointerEventData PointerEventData = new PointerEventData(EventSystem.current);
            PointerEventData.position = MousePosition;

            GraphicRaycaster Raycaster = canvas.GetComponent<GraphicRaycaster>();

            var Results = new System.Collections.Generic.List<RaycastResult>();
            Raycaster.Raycast(PointerEventData, Results);

            // Loop door de resultaten
            foreach (var result in Results)
            {
                if (result.gameObject.name == "Title")//clicked Title
                {
                    if (result.gameObject.transform.childCount != 0)
                    {
                        Debug.Log(result.gameObject.transform.GetChild(0).name);
                        Destroy(result.gameObject.transform.GetChild(0).gameObject);
                    }
                }
                else if (result.gameObject.name == "Author")//clicked Author
                {
                    if (result.gameObject.transform.childCount != 0)
                    {
                        Destroy(result.gameObject.transform.GetChild(0).gameObject);
                    }
                }
                else if (result.gameObject.name == "PublicationDate")//clicked publication date
                {
                    if (result.gameObject.transform.childCount != 0)
                    {
                        Destroy(result.gameObject.transform.GetChild(0).gameObject);
                    }
                }
                else if (result.gameObject.name == "Publisher")//clicked Publisher
                {
                    if (result.gameObject.transform.childCount != 0)
                    {
                        Destroy(result.gameObject.transform.GetChild(0).gameObject);
                    }
                }
                else if (result.gameObject.name == "Due date")//clicked due date
                {
                    if (result.gameObject.transform.childCount != 0)
                    {
                        Destroy(result.gameObject.transform.GetChild(0).gameObject);
                    }
                }   
            }
        }
    }
}
