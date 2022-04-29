using Markdig;
using Microsoft.EntityFrameworkCore;
using PersonalBlogPracticeWebsite.Data;
using PersonalBlogPracticeWebsite.Data.Article;

namespace PersonalBlogPracticeWebsite.Services.Article;

public class ArticleReader : IArticleReader
{
    private readonly IHttpClientFactory _factory;
    private readonly ArticleDbContext _context;
    public ArticleReader(IHttpClientFactory factory, ArticleDbContext context)
    {
        _factory = factory;
        _context = context;
    }

    private static string GetHtmlFromMarkDown(string markDown)
    {
        return Markdown.ToHtml(markDown);
    }

    public async Task<string> GetHtmlFromArticleName(string articleName)
    {
        var article = _context.Articles.Include("ArticleInfo").Include("ArticleContent").Single(b => b.ArticleInfo.Name == articleName);
        
        if (article.ArticleContent.HtmlContent != null)
            return article.ArticleContent.HtmlContent;

        if (article.ArticleContent.MarkDownContent != null)
            return GetHtmlFromMarkDown(article.ArticleContent.MarkDownContent);

        if (article.ArticleContent.MarkDownUrl == null)
            throw new Exception("Wrong Markdown format (no content or url)");
        
        var client = _factory.CreateClient();
        var md = await client.GetStringAsync(article.ArticleContent.MarkDownUrl);

        return GetHtmlFromMarkDown(md);
    }
}
