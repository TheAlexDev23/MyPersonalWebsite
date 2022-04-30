using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlogPracticeWebsite.Pages.Account; 

public class Logout : PageModel {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<Logout> _logger;

    public Logout(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<Logout> logger) {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }
    
    public void OnGet() { }
    
    public async Task<IActionResult> OnPostAsync(string returnUrl) {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            return RedirectToPage("/Index");
        }
    }
}