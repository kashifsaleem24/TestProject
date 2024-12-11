using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext()
        {
        }

        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
        {
        }
        public DbSet<Test> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships or seed data here if needed
            base.OnModelCreating(modelBuilder);
        }


    }
}
