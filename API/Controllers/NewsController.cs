using System.ComponentModel.DataAnnotations;
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
    
    [HttpGet]
    [Route("/api/feed")]
    public IEnumerable<NewsFeedItem> GetArticleFeed()
    {
        return _service.GetArticleFeed();
    }
    
    [HttpGet]
    [Route("/api/articles")]
    public IEnumerable<Article> GetArticles([FromQuery] [MinLength(3)] string searchTerm, [FromQuery]int pageSize)
    {
        return _service.SearchArticle(searchTerm, pageSize);
    }

    [HttpPost]
    [Route("/api/articles")]
    public Article PostArticle([FromBody]Article article)
    {
        return _service.CreateArticle(article.Headline, article.Body, article.Author, article.ArticleImgUrl);
    }
    
    [HttpGet]
    [Route("/api/articles/{articleId}")]
    public Article GetArticle([FromRoute] int articleId)
    {
        return _service.GetArticle(articleId);
    }
    
    [HttpPut]
    [Route("/api/articles/{articleId}")]
    public Article PutSpecificArticle([FromBody]Article article)
    {
        return _service.UpdateArticle(article.ArticleId, article.Headline, article.Body, article.Author, article.ArticleImgUrl);
    }
    
    [HttpDelete]
    [Route("/api/articles/{articleId}")]
    public object DeleteArticle([FromRoute] int articleId)
    {
        return _service.DeleteArticle(articleId);
    }
    
}
