using AutoMapper;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(
        IAccountService accountService,
        IEmailService emailService,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _accountService = accountService;
        _emailService = emailService;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser user = _userManager.FindByEmailAsync(model.Email).Result;
            if (user != null)
            {
                await _signInManager.CreateUserPrincipalAsync(user);
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    UserHelper.IdUser = user.Id;
                    UserHelper.UserName = user.UserName;
                        if (UserHelper.UserName == "moderator")
                        {
                            return RedirectToAction("Index", "Moderator");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
            }

            ModelState.AddModelError("", "Неверный Email или пароль");
            ModelState.AddModelError("", "Подтвердите Email");
        }
        return View();

    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            ApplicationUserVM newUser = new ApplicationUserVM
            {
                UserName = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUserVM, ApplicationUser>();
            });
            IMapper map = config.CreateMapper();
            ApplicationUser user = map.Map<ApplicationUserVM, ApplicationUser>(newUser);

            string rgx = @"^(?=.+[0-9])(?=.+[!@#$%^&*])(?=.+[a-z])(?=.+[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}$";

                if (Regex.IsMatch(model.Password, rgx))
                {

                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        bool roleCheck = await _roleManager.RoleExistsAsync("User");
                        if (!roleCheck)
                        {
                            IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole("User"));
                        }
                        await _userManager.AddToRoleAsync(user, "User");
                        SendMessage(user);
                        return PartialView("DisplayEmail");
                    }
                }
                else
                {
                    ModelState.AddModelError("", " Пароль от 6 символов с использованием цифр, спец. символов, латиницы, наличием строчных и прописных символов.");
                }

            ModelState.AddModelError("", "Пользователь с таким Еmail или именем уже существует");
        }
        return View(model);
    }


    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        UserHelper.IdUser = null;            
        return RedirectToAction("Login", "Account");
    }

    public async void SendMessage(ApplicationUser user)
    {
        ApplicationUser u = _userManager.FindByEmailAsync(user.Email).Result;
        string code = await _userManager.GenerateEmailConfirmationTokenAsync(u);
        string callbackUrl = Url.Action("ConfirmEmail", "Account", new { email = user.Email, code }, protocol: Request.Scheme);
        try
        {
            await _emailService.SendEmailAsync(user.Email, "Для завершения регистрации перейдите по ссылке: <a href=\"" + callbackUrl + "\"> завершить регистрацию</a>");
        }
        catch (Exception) { }

    }

    public IActionResult ConfirmEmail(string email, string code)
    {
        if (email != null && code != null)
        {
            IdentityResult result = _userManager.ConfirmEmailAsync(_userManager.FindByEmailAsync(email).Result, code).Result;

            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        return View("Error");
    }

}
}