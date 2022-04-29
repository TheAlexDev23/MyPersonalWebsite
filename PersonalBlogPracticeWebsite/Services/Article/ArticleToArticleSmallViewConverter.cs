using PersonalBlogPracticeWebsite.Pages.Partials;

namespace PersonalBlogPracticeWebsite.Services.Article;

public class ArticleToArticleSmallViewConverter : IArticleToArticleSmallViewConverter {
    public ArticleSmallViewPartial Convert(Data.Article.Article article) {
        return new()
        {
            ArticleAuthor = article.ArticleInfo.AuthorName,
            ArticleTitle = article.ArticleInfo.Name,
            ImageUrl = article.ArticleInfo.ThumbnailImage
        };
    }
}