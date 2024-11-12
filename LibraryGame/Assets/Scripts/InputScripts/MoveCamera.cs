using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Vectors")]
    private Vector3 BookInspectPos = new Vector3(0, 1, -10); //3
    private Vector3 RuleInspecPos = new Vector3(0, 2, -14); //2
    private Vector3 AllInspecPos = new Vector3(0, 2, -18); //1

    [Header("Information")]
    private float Speed = 5f;
    public bool IsScrolling;
    private float PosNumber = 3;

    [Header("Animator")]
    public Animator Ani;

    private void Start()
    {
        Ani.Play("PickUpTheBook");
    }

    private void Update()
    {
        DetectScrolling();
    }

    public void DetectScrolling()
    {
        if (!IsScrolling)
        {
            if (Input.mouseScrollDelta.y > 0)//Upwards
            {
                if(PosNumber != 3)
                {
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
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, EndPos, Speed*Time.deltaTime);
            yield return null;
        }
        IsScrolling = false;
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
                Ani.speed = 1;
                Ani.Play("LayDownTheBook");
            }
        }
        else if(PosNumber == 2)
        {
            if(Numberadd == 1)
            {
                StartCoroutine(MoveTheCamera(BookInspectPos));
                PosNumber += 1;
                Ani.speed = 1;
                Ani.Play("PickUpTheBook");
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
