using Markdig;
using Microsoft.EntityFrameworkCore;
using PersonalBlogPracticeWebsite.Data.Article;

namespace PersonalBlogPracticeWebsite.Services.Article;

public class ArticleReader : IArticleReader {
    private readonly ArticleDbContext _context;
    private readonly IHttpClientFactory _factory;

    public ArticleReader(IHttpClientFactory factory, ArticleDbContext context) {
        _factory = factory;
        _context = context;
    }

    public async Task<string> GetHtmlFromArticleName(string articleName) {
        var article = _context.Articles.Include("ArticleInfo").Include("ArticleContent")
            .Single(b => b.ArticleInfo.Name == articleName);

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

    private static string GetHtmlFromMarkDown(string markDown) {
        return Markdown.ToHtml(markDown);
    }
}