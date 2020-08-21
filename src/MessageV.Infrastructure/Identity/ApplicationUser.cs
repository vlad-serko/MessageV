using System;
using Microsoft.AspNetCore.Identity;

namespace MessageV.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {   
        public Guid ChatUserId { get; set; }
    }
}