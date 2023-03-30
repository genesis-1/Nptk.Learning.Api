using Microsoft.EntityFrameworkCore;
using Nptk.Learning.Entities;
using Nptk.Learning.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nptk.Learning.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
 : base(options)
        {
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }


    }
}
