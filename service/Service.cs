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

    public Article GetArticle(int article_Id)
    {
        try
        {
            return _repository.GetArticle(article_Id);
        }
        catch (Exception)
        {
            throw new Exception("Could not get Article");
        }
    }
    
    public IEnumerable<NewsFeedItem> GetArticleFeed()
    {
        try
        {
            return _repository.GetArticleFeed();
        }
        catch (Exception)
        {
            throw new Exception("Could not get Article Feed");
        }
    }
    
    public Article CreateArticle(string headline, string body, string author, string articleImgUrl)
    {
        try
        {
            return  _repository.CreateArticle(headline, body, author, articleImgUrl);
        }
        catch (Exception)
        {
            throw new Exception("Could not create Article");
        }
    }
    
    public object DeleteArticle(int articleid)
    {
        try
        {
            return  _repository.DeleteArticle(articleid);
        }
        catch (Exception)
        {
            throw new Exception("Could not delete Article");
        }
    }
    
    public Article UpdateArticle(int article_Id, string headline, string body, string author, string articleImgUrl)
    {
        try
        {
            return  _repository.UpdateArticle(article_Id,  headline,  body,  author,  articleImgUrl);
        }
        catch (Exception)
        {
            throw new Exception("Could not update Article");
        }
    }
    
    public IEnumerable<Article> SearchArticle(string searchTerm, int pageSize)
    {
        try
        {
            return _repository.SearchArticle(searchTerm, pageSize);
        }
        catch (Exception)
        {
            throw new Exception("Could not find Article");
        }
    }

}