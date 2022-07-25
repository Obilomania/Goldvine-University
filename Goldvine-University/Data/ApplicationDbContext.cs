using Goldvine_University.Models;
using IdentityFrameWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Goldvine_University.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
