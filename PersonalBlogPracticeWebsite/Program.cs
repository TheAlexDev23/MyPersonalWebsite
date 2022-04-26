using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using PersonalBlogPracticeWebsite.Data;
using PersonalBlogPracticeWebsite.Services;


var builder = WebApplication.CreateBuilder(args);

//Add EF Core
builder.Services.AddDbContext<ArticleDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IArticleReader, ArticleReader>();

builder.Services.AddHttpClient();

//Add razor pages and configure HSTS
builder.Services.AddRazorPages();

builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(5); //A random value that should work
});

var app = builder.Build();

app.UseStatusCodePagesWithRedirects("/Errors/e{0}");

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });

app.Run();
