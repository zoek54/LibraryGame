using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookCheckScript : MonoBehaviour
{
    public ScriptableBook CorrectBook;
    public GameObject CurrentBook;

    [Header("Sounds")]
    public GameObject WrongAwnser;
    public GameObject CorrectAwnser;
    public GameObject BookDrop;
    public GameObject BookPickUp;

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


    [Header("Other Information")]
    public bool BookIsCorrect;
    public bool BookHasBeenChecked;
    private GameObject Buttons;
    public GameObject Book;
    public GameObject LibraryCard;
    public List<GameObject> Charachters;
    public GameObject AliveCharacter;

    private float HowManyAwnserFault;
    private float HowManyAwnserPlayer;
    private bool PlayerHasCorrectlyCircled;

    public List<GameObject> AllCircles;

    [Header("Refrences")]
    private CreateBook createBook;
    private BookStateHandler bookStateHandler;

    //check elke diffrences of er een verschil is als er een verschil check of deze bool het zelfde is dan de gene die geselecteerd zijn met nog meer bools

    private void Start()
    {
        Buttons = GameObject.Find("Buttons");
        Buttons.SetActive(false);
        createBook = GameObject.Find("CreateBook").GetComponent<CreateBook>();
        bookStateHandler = GameObject.Find("BookStateHandler").GetComponent<BookStateHandler>();

        NewCharacter();
    }

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
        Buttons.SetActive(true);
    }

    //check here if what player selected is indeed wrong;
    public void CheckWhatIsWrong()
    {
        HowManyAwnserPlayer = 0;
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
                            StartCoroutine(HideBook());
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
                            StartCoroutine(HideBook());
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

    public IEnumerator HideBook()
    {
        StartCoroutine(Book.GetComponent<BookAnimations>().RotateBookDown(true));

        yield return new WaitForSeconds(2f);

        //hide the book;
        Destroy(Book);
        Destroy(LibraryCard);
        ResetBools();
        StartCoroutine(AliveCharacter.GetComponent<MoveCharacter>().MoveToExit());
    }

    public void SpawnNewBook()
    {
        //spawn new book
        createBook.ChooseNewBook();

        //sounds
        GameObject SpawendBookDrop = Instantiate(BookDrop);
        DeleteSound(SpawendBookDrop , 3f);
    }

    public void ResetBools()
    {
        CircledName = false;
        CircledAuthor = false;
        CircledPublisher = false;
        CircledPublicationDate = false;
        CircledDueDate = false;

        NameIsFalse = false;
        AuthorIsFalse = false;
        PublisherIsFalse = false;
        PublicationDateIsFalse = false;
        DueDateIsFalse = false;

        BookIsCorrect = false;
        BookHasBeenChecked = false;
        Buttons.SetActive(false);
        PlayerHasCorrectlyCircled = false;
        bookStateHandler.BookIsLayingDown = true;

        foreach(GameObject Circle in AllCircles)
        {
            Destroy(Circle);
        }
        AllCircles.Clear();

        //reset screen text
        TextMeshProUGUI ScreenText = GameObject.Find("ScreenText").GetComponent<TextMeshProUGUI>();
        ScreenText.text = " Title: <br> Author: <br> Publisher: <br> Publish date: <br> Due date:";
    }
    //volgende keer hier verder met het boek weer neerleggen en een nieuw boek maken daarbij alles resetten;

    public void NewCharacter()
    {
        GameObject SpawnendCharacter = Instantiate(Charachters[Random.Range(0, Charachters.Count)]);
        SpawnendCharacter.transform.position = new Vector3(2.44f, 0, -4.53f);
    }

    public IEnumerator PickUpBook()
    {
        GameObject SpawnendBookPickUp = Instantiate(BookPickUp);
        DeleteSound(SpawnendBookPickUp, 3f);
        yield return new WaitForSeconds(0.1f);

        //play animation
        StartCoroutine(Book.GetComponent<BookAnimations>().PickBookUp());
    }
}
