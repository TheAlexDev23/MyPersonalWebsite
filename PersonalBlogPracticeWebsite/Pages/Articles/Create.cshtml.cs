using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Services;

namespace PersonalBlogPracticeWebsite.Pages.Articles;

public class Create : PageModel
{
    private IEmailSender _sender { get; set; }
    private IConfiguration _conf { get; set; }

    public Create(IEmailSender sender, IConfiguration conf)
    {
        _sender = sender;
        _conf = conf;
    }

    public void OnGet() { }

    [BindProperty] public Input formSubmit { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        await _sender.Send(_conf["creation_sender_reciever"],
            $"New Article Submition by: {formSubmit.AuthorName} " +
            $"({formSubmit.CreationDate})\n" +
            $"{formSubmit.Content}");

        return RedirectToPage("/Articles/CreationDone");
    }
    
    public class Input
    {
        [MaxLength(100)]
        [Required]
        public string AuthorName { get; set; }
        
        [Required]
        public DateTime CreationDate { get; set; }
        
        [MaxLength(10000)]
        [Required]
        public string Content { get; set; }
    }
}
