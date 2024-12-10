using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Vectors")]
    private Vector3 BookInspectPos = new Vector3(5.58f, 1.79f, -0.28f); //3
    private Vector3 RuleInspecPos = new Vector3(6.66f, 1.79f, -0.28f); //2
    private Vector3 AllInspecPos = new Vector3(7.34f, 2.1f, -0.28f); //1

    [Header("Information")]
    public float ScrollingSpeed;
    public bool IsScrolling;
    public bool IsPlayingAnimation;
    private float PosNumber = 3;

    //other scripts;
    public BookAnimations bookAnimations;
    public MoveLibraryCard moveLibraryCard;

    private void Update()
    {
        DetectScrolling();
    }

    public void DetectScrolling()
    {
        if (!IsScrolling && !IsPlayingAnimation)
        {
            if (Input.mouseScrollDelta.y > 0)//Upwards
            {
                if(PosNumber != 3)
                {
                    Debug.Log("ddeed");
                    CheckWhatLocation(1);
                    IsScrolling = true;
                }
            }
            else if (Input.mouseScrollDelta.y < 0)//downwards
            {
                if(PosNumber != 1)
                {
                    CheckWhatLocation(-1);
                    IsScrolling = true;
                }
            }
        }
    }

    public IEnumerator MoveTheCamera(Vector3 EndPos)
    {
        while(Vector3.Distance(Camera.main.transform.position, EndPos) > 0.1f)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, EndPos, ScrollingSpeed*Time.deltaTime);
            yield return null;
        }
        IsScrolling = false;
        IsPlayingAnimation = false;
    }

    public void CheckWhatLocation(int Numberadd)
    {
        if(PosNumber == 3)
        {
            if(Numberadd == 1)
            {
                IsScrolling = false;
            }
            else if(Numberadd == -1)
            {
                StartCoroutine(MoveTheCamera(RuleInspecPos));
                PosNumber -= 1;

                //play the laydownthebookhere
                StartCoroutine(bookAnimations.RotateBookDown(false));
                StartCoroutine(moveLibraryCard.MoveBack());

                IsPlayingAnimation = true;
            }
        }
        else if(PosNumber == 2)
        {
            if(Numberadd == 1)
            {
                StartCoroutine(MoveTheCamera(BookInspectPos));
                PosNumber += 1;
            }
            else if (Numberadd == -1)
            {
                StartCoroutine(MoveTheCamera(AllInspecPos));
                PosNumber -= 1;
            }
        }
        else if (PosNumber == 1)
        {
            if (Numberadd == 1)
            {
                StartCoroutine(MoveTheCamera(RuleInspecPos));
                PosNumber += 1;
            }
            else if (Numberadd == -1)
            {
                IsScrolling = false;
            }
        }
    }
}
