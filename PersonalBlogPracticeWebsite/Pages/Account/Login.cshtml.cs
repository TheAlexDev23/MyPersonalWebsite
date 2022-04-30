using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlogPracticeWebsite.Pages.Account; 

public class Login : PageModel {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public Login(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync() {
        if (!ModelState.IsValid) {
            return Page();
        }
        var user = await _userManager.FindByEmailAsync(LogModel.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login");
            return Page();
        }
        if (!user.EmailConfirmed)
        {
            ModelState.AddModelError(string.Empty, "Confirm your email first");
        }

        var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, LogModel.Password, isPersistent: LogModel.KeepSingedIn, lockoutOnFailure: false);
        if (!passwordSignInResult.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Invalid login");
            return Page();
        }

        return RedirectToPage("/Index"); 
    }
    
    [BindProperty] public LoginModel LogModel { get; set; }

    public class LoginModel {
        [EmailAddress(ErrorMessage = "Not a valid mail")]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [Display(Name = "Remember me")] public bool KeepSingedIn { get; set; }
    } 
}