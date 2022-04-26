using Microsoft.EntityFrameworkCore;

namespace PersonalBlogPracticeWebsite.Data;

public class ArticleDbContext : DbContext
{
    public ArticleDbContext(DbContextOptions<ArticleDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Article> Articles { get; set; }
}
