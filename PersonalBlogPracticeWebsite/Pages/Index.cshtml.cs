using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Data;
using PersonalBlogPracticeWebsite.Pages.Partials;
using PersonalBlogPracticeWebsite.Tests;

namespace PersonalBlogPracticeWebsite.Pages;

public class Index : PageModel
{
    private readonly ArticleDbContext _context;

    public Index(ArticleDbContext context)
    {
        _context = context;
    }

    public List<ArticleSmallViewPartial> recomemdedArticles { get; set; } = new()
    {
        new()
        {
            ImageUrl = "images/artice-test.jpg",
            ArticleTitle = "Brainf*ck",
            ArticleAuthor = "Alex Dev"
        },
        new()
        {
            ImageUrl = "images/artice-test.jpg",
            ArticleTitle = "Video Player",
            ArticleAuthor = "Alex Dev"
        }
    };


    public void OnGet()
    {
    }
}