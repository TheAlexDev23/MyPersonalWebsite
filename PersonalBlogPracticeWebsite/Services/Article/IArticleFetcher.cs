namespace PersonalBlogPracticeWebsite.Services.Article;

public interface IArticleFetcher {
    public List<Data.Article.Article> GetAllArticles();
}