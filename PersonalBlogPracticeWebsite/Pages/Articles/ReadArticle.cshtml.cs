using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Services.Article;

namespace PersonalBlogPracticeWebsite.Pages.Articles;

public class ReadArticle : PageModel
{
    private IArticleReader _reader;

    public ReadArticle(IArticleReader reader)
    {
        _reader = reader;
    }
    public string htmlContent { get; set; }
    public string ArticleName { get; set; }
    
    public async Task<IActionResult> OnGetAsync(string articleName)
    {
        if (articleName is null)
        {
            return RedirectToPage("AllArticles");
        }

        ArticleName = articleName;

        htmlContent = await _reader.GetHtmlFromArticleName(articleName);
        return Page();
    }
}