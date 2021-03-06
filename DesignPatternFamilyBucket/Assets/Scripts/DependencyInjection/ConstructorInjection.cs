using System;
using UnityEngine;

public class ConstructorInjection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var description_0 = new Description_0();
        var book_0 = new Book(description_0);//将 IDescription 依赖性需求，注入到Book中
        book_0.Read();

        var description_1 = new Description_1();
        var book_1 = new Book(description_1);//将 IDescription 依赖性需求，注入到Book中
        book_1.Read();
    }
}

public class Book
{
    private readonly IDescription m_description;
    public Book(IDescription description)
    {
        if (description == null)
        {
            throw new ArgumentNullException("description");
        }
        m_description = description;
    }

    public void Read()
    {
        m_description.ToContent();
    }
}


public interface IDescription
{
    void ToContent();
}

public class Description_0 : IDescription
{
    public void ToContent()
    {
        Debug.Log("内容_0");
    }
}

public class Description_1 : IDescription
{
    public void ToContent()
    {
        Debug.Log("内容_1");
    }
}
