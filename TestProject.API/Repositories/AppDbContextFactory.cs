using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<TestAppDbContext>
    {
        public TestAppDbContext CreateDbContext(string[] args)
        {
           
            var optionsBuilder = new DbContextOptionsBuilder<TestAppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TestDB;MultipleActiveResultSets=True;persist security info=false;TrustServerCertificate=true;User Id=sa;Password=sa123;"); 

            return new TestAppDbContext(optionsBuilder.Options);
        }
    }
}
