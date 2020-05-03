using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Website.Models
{
    public class IdentityAppContex : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public IdentityAppContex(DbContextOptions<IdentityAppContex> options) : base(options)
        {

        }
    }
}
