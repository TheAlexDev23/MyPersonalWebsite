using System.Net;
using System.Net.Mail;

namespace PersonalBlogPracticeWebsite.Services;

public class EmailSender : IEmailSender {
    private IConfiguration _conf { get; }
    public EmailSender(IConfiguration conf) {
        _conf = conf;
    }

    public Task Send(string to, string subject, string message) {
        var client = new SmtpClient
        {
            Port = 587,
            Host = "smtp.gmail.com", //or another email sender provider
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_conf["email_sender_address"], _conf["email_sender_passwd"])
        };
        
        return client.SendMailAsync(_conf["email_sender_address"], to, subject,
            message);
    }
}
