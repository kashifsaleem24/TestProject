using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkerService
{
    public class UpsertJob
    {
        private readonly TestAppDbContext _dbContext;

        public UpsertJob(TestAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ExecuteUpsert()
        {
            var entity = _dbContext.Test
              .FirstOrDefault(e => e.Id == 1);

            if (entity == null)
            {
                // Insert new record
                _dbContext.Test.Add(new Models.Test{ FirstName = "test", LastName = "test 1", Email = "test@test.com" });
            }
            else
            {
                // Update existing record
                entity.FirstName = "abc";
                entity.LastName= "xyz";
                _dbContext.Update(entity);
            }

            _dbContext.SaveChanges();
        }
    }
}

