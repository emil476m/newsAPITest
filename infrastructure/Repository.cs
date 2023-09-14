using System.ComponentModel.DataAnnotations;
using Dapper;
using infrastructure.DataModels;
using Npgsql;

namespace infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public IEnumerable<NewsFeedItem> GetArticleFeed()
    {
        var sql = $@"SELECT 
        articleid as {nameof(NewsFeedItem.ArticleId)}, 
        headline as {nameof(NewsFeedItem.Headline)}, 
        left (body, 50)as {nameof(NewsFeedItem.Body)},  
        articleimgurl as {nameof(NewsFeedItem.ArticleImgUrl)} FROM news.articles";
        
        using(var conn = _dataSource.OpenConnection())
        {
            return conn.Query<NewsFeedItem>(sql);
        }
    }
    
    
    public Article GetArticle(int article_Id)
    {
        var sql = $@"SELECT 
        articleid as {nameof(Article.ArticleId)}, 
        headline as {nameof(Article.Headline)}, 
        body as {nameof(Article.Body)}, 
        author as {nameof(Article.Author)}, 
        articleimgurl as {nameof(Article.ArticleImgUrl)} FROM news.articles WHERE articleid = @article_Id";
        
        using(var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new {article_Id});
        }
    }
    
    public Article CreateArticle(string headline, string body, string author, string articleImgUrl)
    {
        var sql = $@"INSERT INTO news.articles (headline, body, author, articleimgurl) VALUES(@headline, @body, @author, @articleImgUrl) RETURNING 
        articleid as {nameof(Article.ArticleId)}, 
        headline as {nameof(Article.Headline)}, 
        body as {nameof(Article.Body)}, 
        author as {nameof(Article.Author)}, 
        articleimgurl as {nameof(Article.ArticleImgUrl)};";
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new {headline, body, author, articleImgUrl});
        }
    }
    
    public object DeleteArticle(int article_Id)
    {
        var sql =  $@"DELETE FROM news.articles WHERE articleid = (@article_Id);";
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new {article_Id}) == 1;
        }
    }
    
    public Article UpdateArticle(int article_Id, string headline, string body, string author, string articleImgUrl)
    {
        var sql = @$"
UPDATE news.articles SET headline = @headline, body = @body, author = @author, articleimgurl = @articleImgUrl WHERE articleid = @article_Id
RETURNING 
    articleid as {nameof(Article.ArticleId)}, 
    headline as {nameof(Article.Headline)}, 
    body as {nameof(Article.Body)}, 
    author as {nameof(Article.Author)}, 
    articleimgurl as {nameof(Article.ArticleImgUrl)};";
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new {article_Id, headline, body, author, articleImgUrl});
        }
    }
    
    public IEnumerable<Article> SearchArticle(string searchTerm, int pageSize)
    {
        var sql =  $@"SELECT * FROM news.articles WHERE body LIKE '%' || @searchTerm || '%' limit @pageSize;";
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Article>(sql, new {searchTerm, pageSize});
        }
    }
    
}