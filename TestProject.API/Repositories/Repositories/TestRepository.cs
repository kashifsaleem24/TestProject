using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly TestAppDbContext _context;

        public TestRepository(TestAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Test>> GetAllTestRecords()
        {
            return await _context.Test.ToListAsync();
        }

        public async Task<bool> SaveTestRecord(Test test)
        {

            bool result = false;

            _context.Test.Add(test);
            await _context.SaveChangesAsync();

            if (test.Id > 0)
            {
                result = true;
            }
            return await Task.FromResult(result);
        }

        public async Task<Test> UpdateTestRecord(Test test)
        {
            _context.Test.Update(test);
            await _context.SaveChangesAsync();

            return await Task.FromResult(test);
        }

    }
}
