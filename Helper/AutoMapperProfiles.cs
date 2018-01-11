using AutoMapper;
using databasePractice.Dtos;
using databasePractice.Models;

namespace databasePractice.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserForDetailDto>();
                
        }
    }
}