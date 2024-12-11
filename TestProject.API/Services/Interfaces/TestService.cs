using AutoMapper;
using DataAccess.Repositories.Interfaces;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;

namespace Services.Interfaces
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<List<TestDto>> GetAllTestRecords()
        {
            try
            {
                var resultList = await _testRepository.GetAllTestRecords();
                return _mapper.Map<List<TestDto>>(resultList);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveTestRecord(TestDto testDto)
        {
            try
            {
                Test test = _mapper.Map<Test>(testDto);
                var result = await _testRepository.SaveTestRecord(test);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TestDto> UpdateTestRecord(TestDto testDto)
        {
            try
            {
                Test test = _mapper.Map<Test>(testDto);
                var result = await _testRepository.SaveTestRecord(test);

                TestDto testRes = _mapper.Map<TestDto>(result);
                return testRes;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
