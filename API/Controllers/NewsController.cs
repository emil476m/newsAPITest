using Microsoft.AspNetCore.Mvc;
using service;
using infrastructure.DataModels;

namespace FullBackendTestProject.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
    private readonly Service _service;

    public NewsController(Service service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/api/articles")]
    public Article PostArticle()
    {
        throw new NotImplementedException();
    }
    
    
    
    
    
    [HttpGet]
    [Route("/api/books")]
    public IEnumerable<Book> GetBooks()
    {
        return _service.GetAllBooks();
    }

    [HttpPost]
    [Route("/api/book")]
    public Book PostBook([FromBody]Book book)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("/api/book/{bookId}")]
    public Book UpdateBook([FromBody] Book book, [FromRoute] int bookId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("/api/book/{bookId}")]
    public object DeleteBook([FromRoute] int bookId)
    {
        throw new NotImplementedException();
    }


}
