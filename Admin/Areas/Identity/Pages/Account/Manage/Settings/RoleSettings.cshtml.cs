using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Admin.Areas.Identity.Data;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Settings
{
	public class RoleSettingsModel : PageModel
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<AdminUser> _userManager;


		public RoleSettingsModel(RoleManager<IdentityRole> roleManager, UserManager<AdminUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
	
		}

        public IEnumerable<IdentityRole> Roles { get; set; }


		[BindProperty]
		[Required]
		public string NewRoleName { get; set; }

        [BindProperty]
        public List<AdminUser> Users { get; set; }

		public List<string> userRoles { get; set; }

		public void OnGet()
		{
			Roles = _roleManager.Roles;

            Users = _userManager.Users.ToList();


            var identity = HttpContext.User.Identity as ClaimsIdentity;
            userRoles = getttingRoles(identity);


		}

		public static List<string> getttingRoles(ClaimsIdentity identity)
		{
			return identity.Claims
				.Where(c => c.Type == ClaimTypes.Role)
				.Select(c => c.Value)
				.ToList();
		}

		public async Task<IActionResult> OnPostCreateAsync()
		{
			if (ModelState.IsValid)
			{
				var result = await _roleManager.CreateAsync(new IdentityRole(NewRoleName));
				if (result.Succeeded)
					return RedirectToPage();
				else
				{
					foreach (var error in result.Errors)
						ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return Page();
		}


		public async Task<IActionResult> OnPostEditAsync(string id)
		{
			return RedirectToPage();
		}

		public async Task<IActionResult> OnPostDeleteAsync(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);
			if (role != null)
			{
				var result = await _roleManager.DeleteAsync(role);
				if (!result.Succeeded)
					ModelState.AddModelError(string.Empty, "Failed to delete role.");
			}
			else
				ModelState.AddModelError(string.Empty, "Role not found.");

			return RedirectToPage();
		}
	}
}