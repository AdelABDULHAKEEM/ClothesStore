using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ClothesStore.Models
{
    public class ApplicationUser : DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {

        }
        public DbSet<User> UserRegistration { get; set; }
    }
}
