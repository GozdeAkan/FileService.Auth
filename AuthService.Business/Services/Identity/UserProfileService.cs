﻿using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthService.Business.Services.Identity;
public class UserProfileService : IProfileService
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserProfileService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim("user_id", user.Id)
            };

            context.IssuedClaims.AddRange(claims);
        }
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}