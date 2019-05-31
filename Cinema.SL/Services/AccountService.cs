using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Cinema.SL.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ApplicationUserVM GetByEmail(string email)
        {
            ApplicationUser account = _unitOfWork.ApplicationUsers.GetByEmail(email);

            return new ApplicationUserVM { UserName = account.UserName, Email = account.Email, PhoneNumber = account.PhoneNumber };
        }

        public ApplicationUserVM GetById(string id)
        {
            ApplicationUser account = _userManager.FindByIdAsync(id).Result;

            return new ApplicationUserVM { Id = account.Id, UserName = account.UserName, Email = account.Email, PhoneNumber = account.PhoneNumber };
        }

        public ApplicationUserVM GetByUserName(string name)
        {
            ApplicationUser account = _userManager.FindByNameAsync(name).Result;

            return new ApplicationUserVM { Id = account.Id, UserName = account.UserName, Email = account.Email, PhoneNumber = account.PhoneNumber };
        }
    }
}
