using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImoApp.Models
{
    public class ImoContext : IdentityDbContext<ApplicationUser>
    {

        public ImoContext(DbContextOptions<ImoContext> options) : base(options)
        {
        }




        public DbSet<MessageChat> MessageChats { get; set; }
    }
}