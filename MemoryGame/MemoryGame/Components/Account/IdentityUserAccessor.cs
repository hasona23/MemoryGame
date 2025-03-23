using MemoryGame.Models;
using Microsoft.AspNetCore.Identity;

namespace MemoryGame.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<GameUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<GameUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
