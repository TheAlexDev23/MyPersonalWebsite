using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlogPracticeWebsite.Services;

namespace PersonalBlogPracticeWebsite.Pages.Account;

public class Register : PageModel {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IEmailSender _sender;

    public Register(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        IEmailSender sender) {
        _userManager = userManager;
        _signInManager = signInManager;
        _sender = sender;
    }

    public void OnGet() { }
    
    //Register the new user
    public async Task<IActionResult> OnPostAsync() {
        if (RegModel.RePassword != RegModel.Password) {
            ModelState.AddModelError(string.Empty, "Passwords don't match");
            return Page();
        }

        if (!ModelState.IsValid) {
            return Page();
        } 
        
        var newUser = new IdentityUser
        {
            UserName = RegModel.UserName,
            Email = RegModel.Email
        };
        
        var userCreationResult = await _userManager.CreateAsync(newUser, RegModel.Password);
        if (!userCreationResult.Succeeded)
        {
            foreach(var error in userCreationResult.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
            return Page();
        }
        
        var ConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

        var emailConfirmationToken = HttpUtility.UrlEncode(ConfirmationToken);

        await SendEmailConfirmationLink(newUser, emailConfirmationToken);

        return RedirectToPage("/Account/CheckYourEmail");
    }

    private async Task SendEmailConfirmationLink(IdentityUser newUser, string? emailConfirmationToken) {
        await _sender.Send(RegModel.Email, "Confirm your email",
            $"In order to verify your email click here: " +
            $"https://{Request.Host}/Account/Register?handler=Confirm&id={newUser.Id}&token={emailConfirmationToken}&persistent={RegModel.KeepSingedIn}");
    }

    public async Task<IActionResult> OnGetConfirmAsync(string id, string token, bool persistent) {
        var user = await _userManager.FindByIdAsync(id);
        if(user == null)
            throw new InvalidOperationException();

        var emailConfirmationResult = await _userManager.ConfirmEmailAsync(user, token);
        if (!emailConfirmationResult.Succeeded)            
            return Content(emailConfirmationResult.Errors.Select(error => error.Description).Aggregate((allErrors, error) => allErrors += ", " + error));

        await _signInManager.SignInAsync(user, persistent);

        return RedirectToPage("/Index");
    }

    [BindProperty] public RegisterModel RegModel { get; set; }

    public class RegisterModel {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [EmailAddress(ErrorMessage = "Not a valid mail")]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Repeat password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Display(Name = "Remember me")] public bool KeepSingedIn { get; set; }
    }
}
