using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nowadays.Models;

namespace Nowadays.Data
{
    public class AplicationDbContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
            {
            }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Project> Projects { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Issue> Issues { get; set; }
            public DbSet<Report> Reports { get; set; }
        }
    }
}