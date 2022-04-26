namespace PersonalBlogPracticeWebsite.Data;

public class Article
{
    public int Id { get; set; }
    public ArticleInfo ArticleInfo { get; set; }
    public ArticleContent ArticleContent { get; set; }
}