using Microsoft.AspNetCore.Identity;
using Travelso_TravelWebsite.Data;

namespace Travelso_TravelWebsite.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load BlogPostAuthorUser with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
