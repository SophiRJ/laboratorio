using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreAuthenticationApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolController : Controller
    {
        private readonly RoleManager<IdentityRole>? _roleManager;
        private readonly UserManager<IdentityUser>? _userManager;
        public RolController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager=roleManager;
            _userManager=userManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager!.Roles;
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            if (!string.IsNullOrWhiteSpace(roleName) && !await _roleManager!.RoleExistsAsync(roleName))
                //ya hace el saeve change
                await _roleManager.CreateAsync(new IdentityRole(roleName));

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userEmail, string roleName)
        {
            var user = await _userManager!.FindByEmailAsync(userEmail);
            if (user != null && await _roleManager!.RoleExistsAsync(roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
