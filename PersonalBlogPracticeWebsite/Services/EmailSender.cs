using System.Net;
using System.Net.Mail;

namespace PersonalBlogPracticeWebsite.Services;

public class EmailSender : IEmailSender
{
    private IConfiguration _conf { get; set; }

    public EmailSender(IConfiguration conf)
    {
        _conf = conf;
    }
    
    public Task Send(string to, string message)
    {
        var client = new SmtpClient
        {
            Port = 587,
            Host = "smtp.gmail.com", //or another email sender provider
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_conf["creation_sender_email"], _conf["creation_sender_passwd"])
        };
        
        return client.SendMailAsync(_conf["creation_sender_reciever"],to, "Someone wants to submit an article", message);
    }
}
