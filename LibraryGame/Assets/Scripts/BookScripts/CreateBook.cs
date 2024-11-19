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
    private TransferBookData transferBookData;
    private BookInformationContainer bookInformationContainer;

    private void Start()
    {
        TitleScript = GameObject.Find("RandomTitle").GetComponent<RandomTitleScript>();
        PublishDateScript = GameObject.Find("RandomPublisherDate").GetComponent<RandomPublishDateScript>();
        PublisherScript = GameObject.Find("RandomPublisher").GetComponent<RandomPublisherScript>();
        DueDateScript = GameObject.Find("RandomDueDate").GetComponent<RandomDueDateScript>();
        AuthorScript = GameObject.Find("RandomAuthor").GetComponent<RandomAuthorScript>();
        transferBookData = GameObject.Find("Book").GetComponent<TransferBookData>();
        bookInformationContainer = GameObject.Find("BookInformationContainer").GetComponent<BookInformationContainer>();

        ChooseNewBook();
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
            Debug.Log("BookIscorrect");

            ScriptableBook TempBook = Books[Random.Range(0, Books.Count)];
            transferBookData.CorrectBook = TempBook;

            TemplateBook.Name = TempBook.Name;
            TemplateBook.Author = TempBook.Author;
            TemplateBook.Publisher = TempBook.Publisher;
            TemplateBook.PublicationDate = TempBook.PublicationDate;
            TemplateBook.DueDate = TempBook.DueDate;

            GameObject.Find("Book").GetComponent<TransferBookData>().SwitchBooks(TemplateBook);
        }
        else if (RandomNumber > 33)
        {
            Debug.Log("BookIsIncorrect");

            ScriptableBook TempBook = Books[Random.Range(0, Books.Count)];
            transferBookData.CorrectBook = TempBook;

            TemplateBook.Name = TempBook.Name;
            TemplateBook.Author = TempBook.Author;
            TemplateBook.Publisher = TempBook.Publisher;
            TemplateBook.PublicationDate = TempBook.PublicationDate;
            TemplateBook.DueDate = TempBook.DueDate;

            ChangeBook();

            GameObject.Find("Book").GetComponent<TransferBookData>().SwitchBooks(TemplateBook);
        }
    }

    public void ChangeBook()
    {
        int RandomNumber = Random.Range(0, 100);
        if(RandomNumber < 20)
        {
            TemplateBook.Name = TitleScript.MakeTitleUp(TemplateBook.Name);
        }
        else if (RandomNumber >= 20 && RandomNumber < 40) //author
        {
            TemplateBook.Author = AuthorScript.MakeAuthorUp(TemplateBook.Author);
        }
        else if(RandomNumber >= 40 && RandomNumber < 60)
        {
            TemplateBook.Publisher = PublisherScript.MakePublisherUp(TemplateBook.Publisher);
        }
        else if (RandomNumber >= 60 && RandomNumber < 80)
        {
            TemplateBook.PublicationDate = PublishDateScript.MakePublicationDateUp(TemplateBook.PublicationDate);
        }
        else if (RandomNumber >= 80 && RandomNumber <= 100)
        {
            TemplateBook.DueDate = DueDateScript.MakeDueDateUp(TemplateBook.DueDate);
        }
    }
}
