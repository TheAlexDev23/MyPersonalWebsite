using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalBlogPracticeWebsite.Data.Article;
using PersonalBlogPracticeWebsite.Services;
using PersonalBlogPracticeWebsite.Services.Article;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

//Add EF Core
builder.Services.AddDbContext<ArticleDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("ArticleDb"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>();

builder.Services.AddTransient<IArticleReader, ArticleReader>();
builder.Services.AddTransient<IArticleFetcher, ArticleFetcher>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IArticleToArticleSmallViewConverter, ArticleToArticleSmallViewConverter>();

builder.Services.AddHttpClient();

//Add razor pages and configure HSTS
builder.Services.AddRazorPages();

builder.Services.AddHsts(options => {
    options.MaxAge = TimeSpan.FromDays(5); //A random value that should work
});

var app = builder.Build();

app.UseStatusCodePagesWithRedirects("/Errors/e{0}");

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment()) app.UseHsts();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });

app.Run();