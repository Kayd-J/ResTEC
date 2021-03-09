using AutoMapper;
using WebServiceResTEC.Models;
using WebServiceResTEC.DTOs;

namespace WebServiceResTEC.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            //Source -> Target
            CreateMap<Admin, AdminReadDto>();
            CreateMap<AdminCreateDto, Admin>();
        }
    }

}