using AutoMapper;
using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Domain to DTO
            CreateMap<Test, TestDto>().ReverseMap();
        }
    }
}
