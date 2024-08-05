using Microsoft.EntityFrameworkCore;
using SecondVersionOfTesting.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondVersionOfTesting.Data
{
    public class UserDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=UnitTesting;Trusted_Connection=true; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
