namespace PersonalBlogPracticeWebsite.Services;

public interface IArticleReader
{
    public Task<string> GetHtmlFromArticleName(string articleName);
}