using System.ComponentModel.DataAnnotations;

namespace infrastructure.DataModels;

public class NewsFeedItem
{
    public string Headline { get; set; }
    public int ArticleId { get; set; }
    public string ArticleImgUrl { get; set; }
    
    [MaxLength(50)]
    public string Body { get; set; }
}