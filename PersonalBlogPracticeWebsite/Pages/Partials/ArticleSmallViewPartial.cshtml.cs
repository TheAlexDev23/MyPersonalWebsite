using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlogPracticeWebsite.Pages.Partials;

public class ArticleSmallViewPartial : PageModel
{
    public string ImageUrl { get; set; }
    public string ArticleTitle { get; set; }
    public string ArticleAuthor { get; set; }
    
    public void OnGet() { }
}