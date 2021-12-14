using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampaignCommander.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<ApplicationUser> Users { get; set;}
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}