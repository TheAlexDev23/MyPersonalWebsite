﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Data;
using PersonalBlogPracticeWebsite.Pages.Partials;
using PersonalBlogPracticeWebsite.Services.Article;

namespace PersonalBlogPracticeWebsite.Pages.Articles;

public class AllArticles : PageModel
{
    private readonly IArticleFetcher _fetcher;
    private readonly IArticleToArticleSmallViewConverter _converter;

    public AllArticles(IArticleFetcher fetcher, IArticleToArticleSmallViewConverter converter)
    {
        _fetcher = fetcher;
        _converter = converter;
    }

    private List<Article> Articles { get; set; }
    public List<ArticleSmallViewPartial> ArticlesSmallView { get; set; } = new List<ArticleSmallViewPartial>();
    public void OnGet()
    {
        Articles = _fetcher.GetAllArticles();
        foreach (var article in Articles)
        {
            ArticlesSmallView.Add(_converter.Convert(article));
        }
    }
}