using EFreelancer.Data;
using EFreelancer.Entities;
using EFreelancer.Models.Global;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EFreelancer.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserLogins> _userManager;
        private readonly SignInManager<UserLogins> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ApplicationDbContext _db;

        public IdentityService(UserManager<UserLogins> userManager, RoleManager<IdentityRole<int>> roleManager, SignInManager<UserLogins> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _db = db;
        }

        // public async Task<UserEntityCreationResult> CreateTraderUser(CreateTraderUserData data)
        // {
        //     var existingLogin = await _userManager.FindByNameAsync(data.Email);

        //     if (existingLogin != null)
        //     {
        //         return new UserEntityCreationResult()
        //         {
        //             Error = "Email has already been used for another account"
        //         };
        //     }

        //     var newUser = new UserLogins
        //     {
        //         UserName = data.Email,
        //         Email = data.Email,
        //         PhoneNumber = data.PhoneNumber,
        //     };

        //     var createdUser = await _userManager.CreateAsync(newUser, data.Password);

        //     if (!createdUser.Succeeded)
        //     {
        //         return new UserEntityCreationResult()
        //         {
        //             Error = createdUser.Errors.Select(x => x.Description).FirstOrDefault()
        //         };
        //     }

        //     return new UserEntityCreationResult()
        //     {
        //         Success = true,
        //         EntityId = newUser.Id
        //     };
        // }
    }
}

