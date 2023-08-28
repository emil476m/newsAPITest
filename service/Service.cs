using infrastructure;
using infrastructure.DataModels;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        try
        {
            return _repository.GetAllBooks();
        }
        catch (Exception)
        {
            throw new Exception("Could not get books");
        }
    }

    public Book CreateBook(string title, string publisher, string coverImgUrl)
    {
        throw new NotImplementedException();
    }

}