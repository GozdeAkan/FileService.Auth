using AuthService.Business.Contracts;
using AuthService.Business.DTOs;
using AuthService.Business.Models.Commands;
using Microsoft.AspNetCore.Identity;


namespace AuthService.Business.Services
{
    public class AccountService : IAccountService
    {
        readonly UserManager<IdentityUser> _userManager;

        public AccountService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterCommand request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Registration failed.");
            }

            return new RegisterResponse();
        }

      
    }
}
