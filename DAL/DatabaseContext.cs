using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.DAL
{
    public class DatabaseContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DatabaseContext(DbContextOptions options): base(options) { }

    }
}
