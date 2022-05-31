using BlogEngine.ViewModels.Account;
using DatabaseAccess;
using DatabaseAccess.DbModels;
using Logic.Services.AddUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(BlogDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(registerViewModel.Login) ?? await _userManager.FindByEmailAsync(registerViewModel.Email);
                if (user == null)
                {
                    user = new User(registerViewModel.Login);
                    user.Email = registerViewModel.Email;
                    user.PhoneNumber = registerViewModel.PhoneNumber;
                    await _userManager.CreateAsync(user, registerViewModel.Password);
                    if ((await _signInManager.PasswordSignInAsync(user, registerViewModel.Password, false, false))
                        .Succeeded)
                    {
                        new AddUserService(_context).AddUser(user);
                        return Redirect("/Dashboard");
                    }

                    ModelState.AddModelError(string.Empty, "Error while registering!");
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.Login);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false))
                        .Succeeded)
                    {
                        return Redirect(loginViewModel.ReturnUrl ?? "/Dashboard");
                    }

                    ModelState.AddModelError(string.Empty, "Invalid username or password!");
                }
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
