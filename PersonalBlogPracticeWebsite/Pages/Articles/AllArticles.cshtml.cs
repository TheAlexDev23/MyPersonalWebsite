using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Data.Article;
using PersonalBlogPracticeWebsite.Pages.Partials;
using PersonalBlogPracticeWebsite.Services.Article;

namespace PersonalBlogPracticeWebsite.Pages.Articles;

public class AllArticles : PageModel {
    private readonly IArticleToArticleSmallViewConverter _converter;
    private readonly IArticleFetcher _fetcher;

    public AllArticles(IArticleFetcher fetcher, IArticleToArticleSmallViewConverter converter) {
        _fetcher = fetcher;
        _converter = converter;
    }

    private List<Article> Articles { get; set; }
    public List<ArticleSmallViewPartial> ArticlesSmallView { get; set; } = new();

    public void OnGet() {
        Articles = _fetcher.GetAllArticles();
        foreach (var article in Articles) ArticlesSmallView.Add(_converter.Convert(article));
    }
}