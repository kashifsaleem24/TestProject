using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<bool> SaveTestRecord(Test test);

        Task<Test> UpdateTestRecord(Test test);

        Task<List<Test>> GetAllTestRecords();
    }
}
