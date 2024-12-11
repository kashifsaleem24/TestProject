using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITestService
    {
        public Task<List<TestDto>> GetAllTestRecords();

        public Task<bool> SaveTestRecord(TestDto testDto);

        public Task<TestDto> UpdateTestRecord(TestDto testDto);
    }
}
