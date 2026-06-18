#nullable disable
#nullable disable
#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MojeVlastniStranka.Web.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class LoginModel : PageModel
	{
		private readonly UserManager<DataAccess.Entities.User> _userManager;
		private readonly SignInManager<DataAccess.Entities.User> _signInManager;
		private readonly ILogger<LoginModel> _logger;

		public LoginModel(SignInManager<DataAccess.Entities.User> signInManager,
			 ILogger<LoginModel> logger,
			 UserManager<DataAccess.Entities.User> userManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public string ReturnUrl { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public class InputModel
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[Display(Name = "Pamatovat si mě?")]
			public bool RememberMe { get; set; }
		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				ModelState.AddModelError(string.Empty, ErrorMessage);
			}

			returnUrl ??= Url.Content("~/");

			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			ReturnUrl = returnUrl;
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			if (ModelState.IsValid)
			{
				// Získat uživatele pomocí e-mailu
				var user = await _userManager.FindByEmailAsync(Input.Email);
				if (user != null)
				{
					// Přihlásit se pomocí ID uživatele a hesla
					var result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
					if (result.Succeeded)
					{
						_logger.LogInformation("User logged in.");
						return LocalRedirect(returnUrl);
					}
					if (result.RequiresTwoFactor)
					{
						return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
					}
					if (result.IsLockedOut)
					{
						_logger.LogWarning("Užívatel je deaktivovaný.");
						return RedirectToPage("./Lockout");
					}
				}

				_logger.LogInformation("Pokus o přihlášení {DT}",
					 DateTime.UtcNow.ToLongTimeString());
				ModelState.AddModelError(string.Empty, "Neuúspěšné přihlášení.");
				return Page();
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}