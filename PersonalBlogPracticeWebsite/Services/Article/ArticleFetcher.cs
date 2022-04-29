using Microsoft.EntityFrameworkCore;
using PersonalBlogPracticeWebsite.Data;
using PersonalBlogPracticeWebsite.Data.Article;

namespace PersonalBlogPracticeWebsite.Services.Article;

public class ArticleFetcher : IArticleFetcher
{
    private ArticleDbContext _context;
    public ArticleFetcher(ArticleDbContext context)
    {
        _context = context;
    }

    public List<Data.Article.Article> GetAllArticles() =>
        _context.Articles.Include("ArticleContent").Include("ArticleInfo").ToList();
}