using PersonalBlogPracticeWebsite.Pages.Partials;

namespace PersonalBlogPracticeWebsite.Services.Article;

public interface IArticleToArticleSmallViewConverter
{
    public ArticleSmallViewPartial Convert(Data.Article article);
}