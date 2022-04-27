namespace PersonalBlogPracticeWebsite.Services.Article;

public interface IArticleReader
{
    public Task<string> GetHtmlFromArticleName(string articleName);
}