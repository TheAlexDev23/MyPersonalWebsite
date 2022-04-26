using PersonalBlogPracticeWebsite.Data;

namespace PersonalBlogPracticeWebsite.Tests;

public class EFMock
{
    public static void Mock(ArticleDbContext context)
    {
        var article1 = new Article()
        {
            ArticleContent = new ArticleContent()
            {
                MarkDownUrl = "https://raw.githubusercontent.com/TheAlexDev23/MyWebsiteArticles/main/Articles/Brainfuck.md"
            },
            ArticleInfo = new ArticleInfo()
            {
                Name = "Brainf*ck",
                AuthorName = "Alex Dev",
                CreationDate = DateTime.Now,
            }
        };
        
        var article2 = new Article()
        {
            ArticleContent = new ArticleContent()
            {
                MarkDownUrl = "https://raw.githubusercontent.com/TheAlexDev23/MyWebsiteArticles/main/Articles/VideoPlayer.md"
            },
            ArticleInfo = new ArticleInfo()
            {
                Name = "Video Player",
                AuthorName = "Alex Dev",
                CreationDate = DateTime.Now,
            }
        };
        
        context.Articles.Add(article1);
        context.Articles.Add(article2);

        context.SaveChanges();
    }
}
