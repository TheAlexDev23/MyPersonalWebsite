namespace PersonalBlogPracticeWebsite.Services;

public interface IEmailSender
{
    public Task Send(string to, string message);
}