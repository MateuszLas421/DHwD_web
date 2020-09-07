using DHwD.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Models
{
    public class AppWebDbContext : DbContext
    {
        public AppWebDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; } 

    }
}
