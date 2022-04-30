using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlogPracticeWebsite.Data.Users;

public class UsersDbContext : IdentityDbContext<IdentityUser> {
    public UsersDbContext(DbContextOptions<UsersDbContext> options) :
        base(options) { }
}