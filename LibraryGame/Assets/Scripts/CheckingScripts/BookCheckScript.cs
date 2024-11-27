using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCheckScript : MonoBehaviour
{
    public ScriptableBook CorrectBook;
    public GameObject CurrentBook;

    [Header("Sounds")]
    public GameObject WrongAwnser;
    public GameObject CorrectAwnser;

    [Header("Bools for circled on book")]
    public bool CircledName;
    public bool CircledAuthor;
    public bool CircledPublisher;
    public bool CircledPublicationDate;
    public bool CircledDueDate;

    [Header("BoolsForBook")]
    private bool NameIsFalse;
    private bool AuthorIsFalse;
    private bool PublisherIsFalse;
    private bool PublicationDateIsFalse;
    private bool DueDateIsFalse;

    public bool BookIsCorrect;
    public bool BookHasBeenChecked;

    private float HowManyAwnserFault;
    private float HowManyAwnserPlayer;
    private bool PlayerHasCorrectlyCircled;

    //check elke diffrences of er een verschil is als er een verschil check of deze bool het zelfde is dan de gene die geselecteerd zijn met nog meer bools

    private void Update()
    {
        PressButton();
    }

    public void CheckBook()
    {
        HowManyAwnserFault = 0;
        TransferBookData transferBookData = CurrentBook.GetComponent<TransferBookData>();
        BookIsCorrect = true;
        if (CorrectBook.Name != transferBookData.Name.text.ToString())
        {
            NameIsFalse = true;
            BookIsCorrect = false;
            HowManyAwnserFault += 1;
        }
        if (CorrectBook.Author != transferBookData.Author.text.ToString())
        {
            AuthorIsFalse = true;
            BookIsCorrect = false;
            HowManyAwnserFault += 1;
        }
        if (CorrectBook.Publisher != transferBookData.Publisher.text.ToString())
        {
            PublisherIsFalse = true;
            BookIsCorrect = false;
            HowManyAwnserFault += 1;
        }
        if (CorrectBook.PublicationDate != transferBookData.PublicationDate.text.ToString())
        {
            PublicationDateIsFalse = true;
            BookIsCorrect = false;
            HowManyAwnserFault += 1;
        }
        if (CorrectBook.DueDate != transferBookData.DueDate.text.ToString())
        {
            DueDateIsFalse = true;
            BookIsCorrect = false;
            HowManyAwnserFault += 1;
        }
        BookHasBeenChecked = true;
    }

    //check here if what player selected is indeed wrong;
    public void CheckWhatIsWrong()
    {
        //Title
        if (CircledName && NameIsFalse)
        {
            Debug.Log("1");
            HowManyAwnserPlayer += 1;
            //correct circled;
        }

        //Author
        if (CircledAuthor && AuthorIsFalse)
        {
            Debug.Log("1");
            HowManyAwnserPlayer += 1;
            //correct circled;
        }

        //publisher
        if (CircledPublisher && PublisherIsFalse)
        {
            Debug.Log("1");
            HowManyAwnserPlayer += 1;
            //correct circled;
        }

        //PublishDate
        if (CircledPublicationDate && PublicationDateIsFalse)
        {
            Debug.Log("1");
            HowManyAwnserPlayer += 1;
            //correct circled;
        }

        //Due date
        if (CircledDueDate && DueDateIsFalse)
        {
            Debug.Log("1");
            HowManyAwnserPlayer += 1;
            //correct circled;
        }

        if(HowManyAwnserFault == HowManyAwnserPlayer)
        {
            PlayerHasCorrectlyCircled = true;
        }
    }

    public void PressButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (BookHasBeenChecked)
                {
                    if (hit.transform.gameObject.tag == "GoodButton")
                    {
                        if (BookIsCorrect)
                        {
                            GameObject SpawnendSound = Instantiate(CorrectAwnser);
                            StartCoroutine(DeleteSound(SpawnendSound, 2f));
                            Debug.Log("Correct");
                        }
                        else
                        {
                            GameObject SpawnendSound = Instantiate(WrongAwnser);
                            StartCoroutine(DeleteSound(SpawnendSound, 2f));
                            Debug.Log("Not correct");
                        }
                    }
                    else if (hit.transform.gameObject.tag == "WrongButton")
                    {
                        CheckWhatIsWrong();
                        if (PlayerHasCorrectlyCircled)
                        {
                            GameObject SpawnendSound = Instantiate(CorrectAwnser);
                            StartCoroutine(DeleteSound(SpawnendSound, 2f));
                            Debug.Log("Correct false");
                        }
                        else
                        {
                            GameObject SpawnendSound = Instantiate(WrongAwnser);
                            StartCoroutine(DeleteSound(SpawnendSound, 2f));
                            Debug.Log("False false");
                        }
                    }
                }
                else
                {
                    Debug.Log("Book has not been checked yet");
                }
            }
        }
    }

    public IEnumerator DeleteSound(GameObject ObjectSound, float Time)
    {
        yield return new WaitForSeconds(Time);
        Destroy(ObjectSound);
    }

    //volgende keer hier verder met het boek weer neerleggen en een nieuw boek maken daarbij alles resetten;
}
