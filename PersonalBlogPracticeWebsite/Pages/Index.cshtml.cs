using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Data.Article;
using PersonalBlogPracticeWebsite.Pages.Partials;

namespace PersonalBlogPracticeWebsite.Pages;

public class Index : PageModel {
    private readonly ArticleDbContext _context;
    private readonly ILogger<Index> _logger;

    public Index(ArticleDbContext context, ILogger<Index> logger) {
        _context = context;
        _logger = logger;
    }

    public List<ArticleSmallViewPartial> recomemdedArticles { get; set; } = new()
    {
        new ArticleSmallViewPartial
        {
            ImageUrl = "images/artice-test.jpg",
            ArticleTitle = "Brainf*ck",
            ArticleAuthor = "Alex Dev"
        },
        new ArticleSmallViewPartial
        {
            ImageUrl = "images/artice-test.jpg",
            ArticleTitle = "Video Player",
            ArticleAuthor = "Alex Dev"
        }
    };


    public void OnGet() { }
}