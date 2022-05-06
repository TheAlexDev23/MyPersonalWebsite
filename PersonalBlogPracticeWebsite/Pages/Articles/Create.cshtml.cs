﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Services;

namespace PersonalBlogPracticeWebsite.Pages.Articles;

[Authorize]
public class Create : PageModel {
    public Create(IEmailSender sender, IConfiguration conf) {
        _sender = sender;
        _conf = conf;
    }

    private IEmailSender _sender { get; }
    private IConfiguration _conf { get; }

    [BindProperty] public Input formSubmit { get; set; }

    public void OnGet() { }
    
    public async Task<IActionResult> OnPostAsync() {
        await _sender.Send(_conf["creation_sender_reciever"],
            "Someone wants to submit a new article",
            $"New Article Submition by: {formSubmit.AuthorName} " +
            $"({formSubmit.CreationDate})\n" +
            $"{formSubmit.Content}");

        return RedirectToPage("/Articles/CreationDone");
    }

    public class Input {
        [MaxLength(100)] [Required] public string AuthorName { get; set; }

        [Required] public DateTime CreationDate { get; set; }

        [MaxLength(10000)] [Required] public string Content { get; set; }
    }
}