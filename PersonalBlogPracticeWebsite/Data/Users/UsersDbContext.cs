using Microsoft.EntityFrameworkCore;

namespace PersonalBlogPracticeWebsite.Data.Users;

public class UsersDbContext : DbContext {
    public UsersDbContext(DbContextOptions<UsersDbContext> options) :
        base(options) { }
}