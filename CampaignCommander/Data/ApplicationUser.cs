using Microsoft.AspNetCore.Identity;

namespace CampaignCommander.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
