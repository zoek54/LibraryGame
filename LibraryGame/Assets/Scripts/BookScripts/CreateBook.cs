using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBook : MonoBehaviour
{
    //zoveel % kans op een echt book of niet
    //daarna zoveel % kans op wat er fout is (even met birdo overleggen);

    public ScriptableBook TemplateBook;
    public List<ScriptableBook> Books;

    private RandomTitleScript TitleScript;
    private RandomPublishDateScript PublishDateScript;
    private RandomPublisherScript PublisherScript;
    private RandomDueDateScript DueDateScript;
    private RandomAuthorScript AuthorScript;
    public TransferBookData transferBookData;
    private BookInformationContainer bookInformationContainer;

    [Header("BoolChecking")]
    private bool TitleIsChanged;
    private bool AuthorIsChanged;
    private bool PublisherIsChanged;
    private bool PublishDateIsChanged;
    private bool DueDateIsChanged;

    private void Start()
    {
        TitleScript = GameObject.Find("RandomTitle").GetComponent<RandomTitleScript>();
        PublishDateScript = GameObject.Find("RandomPublisherDate").GetComponent<RandomPublishDateScript>();
        PublisherScript = GameObject.Find("RandomPublisher").GetComponent<RandomPublisherScript>();
        DueDateScript = GameObject.Find("RandomDueDate").GetComponent<RandomDueDateScript>();
        AuthorScript = GameObject.Find("RandomAuthor").GetComponent<RandomAuthorScript>();
        bookInformationContainer = GameObject.Find("BookInformationContainer").GetComponent<BookInformationContainer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChooseNewBook();
        }
    }

    public void ChooseNewBook()
    {
        int RandomNumber = Random.Range(0, 100);

        if(RandomNumber <= 33)
        {
            Debug.Log("Good Book");
            ScriptableBook TempBook = Books[Random.Range(0, Books.Count)];
            transferBookData.CorrectBook = TempBook;

            TemplateBook.Name = TempBook.Name;
            TemplateBook.Author = TempBook.Author;
            Debug.Log(TemplateBook.Author);
            TemplateBook.Publisher = TempBook.Publisher;
            TemplateBook.PublicationDate = TempBook.PublicationDate;
            TemplateBook.DueDate = TempBook.DueDate;

            transferBookData.SwitchBooks(TemplateBook);
        }
        else if (RandomNumber > 33)
        {
            ScriptableBook TempBook = Books[Random.Range(0, Books.Count)];
            transferBookData.CorrectBook = TempBook;

            TemplateBook.Name = TempBook.Name;
            TemplateBook.Author = TempBook.Author;
            TemplateBook.Publisher = TempBook.Publisher;
            TemplateBook.PublicationDate = TempBook.PublicationDate;
            TemplateBook.DueDate = TempBook.DueDate;

            ChangeBook();
            ResetBools();

            transferBookData.SwitchBooks(TemplateBook);
        }
    }

    public void ChangeBook()
    {
        int RandomNumber = Random.Range(0, 100);
        if (RandomNumber < 20)
        {
            if (!TitleIsChanged)
            {
                TemplateBook.Name = TitleScript.MakeTitleUp(TemplateBook.Name);

                TitleIsChanged = true;
                int RandomNumber2 = Random.Range(0, 100);
                if (RandomNumber2 <= 45)
                {
                    ChangeBook();
                }
                else
                {
                    ResetBools();
                }
            }
            else
            {
                if (!TitleIsChanged || !AuthorIsChanged || !PublisherIsChanged || !PublishDateIsChanged || !DueDateIsChanged)
                {
                    ChangeBook();
                }
            }
        }
        else if (RandomNumber >= 20 && RandomNumber < 40) //author
        {
            if (!AuthorIsChanged)
            {
                TemplateBook.Author = AuthorScript.MakeAuthorUp(TemplateBook.Author);

                AuthorIsChanged = true;
                int RandomNumber2 = Random.Range(0, 100);
                if (RandomNumber2 <= 45)
                {
                    ChangeBook();
                }
                else
                {
                    ResetBools();
                }
            }
            else
            {
                if (!TitleIsChanged || !AuthorIsChanged || !PublisherIsChanged || !PublishDateIsChanged || !DueDateIsChanged)
                {
                    ChangeBook();
                }
            }
        }
        else if (RandomNumber >= 40 && RandomNumber < 60)
        {
            if (!PublisherIsChanged)
            {
                TemplateBook.Publisher = PublisherScript.MakePublisherUp(TemplateBook.Publisher);

                PublisherIsChanged = true;
                int RandomNumber2 = Random.Range(0, 100);
                if (RandomNumber2 <= 45)
                {
                    ChangeBook();
                }
                else
                {
                    ResetBools();
                }
            }
            else
            {
                if (!TitleIsChanged || !AuthorIsChanged || !PublisherIsChanged || !PublishDateIsChanged || !DueDateIsChanged)
                {
                    ChangeBook();
                }
            }
        }
        else if (RandomNumber >= 60 && RandomNumber < 80)
        {
            if (!PublishDateIsChanged)
            {
                TemplateBook.PublicationDate = PublishDateScript.MakePublicationDateUp(TemplateBook.PublicationDate);

                PublishDateIsChanged = true;
                int RandomNumber2 = Random.Range(0, 100);
                if (RandomNumber2 <= 45)
                {
                    ChangeBook();
                }
                else
                {
                    ResetBools();
                }
            }
            else
            {
                if (!TitleIsChanged || !AuthorIsChanged || !PublisherIsChanged || !PublishDateIsChanged || !DueDateIsChanged)
                {
                    ChangeBook();
                }
            }
        }
        else if (RandomNumber >= 80 && RandomNumber <= 100)
        {
            if (!DueDateIsChanged)
            {
                TemplateBook.DueDate = DueDateScript.MakeDueDateUp(TemplateBook.DueDate);

                DueDateIsChanged = true;
                int RandomNumber2 = Random.Range(0, 100);
                if (RandomNumber2 <= 45)
                {
                    ChangeBook();
                }
                else
                {
                    ResetBools();
                }
            }
            else
            {
                if (!TitleIsChanged || !AuthorIsChanged || !PublisherIsChanged || !PublishDateIsChanged || !DueDateIsChanged)
                {
                    ChangeBook();
                }
            }
        }
    }

    public void ResetBools()
    {
        TitleIsChanged = false;
        AuthorIsChanged = false;
        PublisherIsChanged = false;
        PublishDateIsChanged = false;
        DueDateIsChanged = false;
    }
}
