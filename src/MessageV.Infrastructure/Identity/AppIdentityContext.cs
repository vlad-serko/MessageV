using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MessageV.Infrastructure.Identity
{
    public class AppIdentityContext : IdentityDbContext<ApplicationUser>
    {
        
    }
}