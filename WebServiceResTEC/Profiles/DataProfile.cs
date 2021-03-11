using AutoMapper;
using WebServiceResTEC.Models;
using WebServiceResTEC.DTOs;

namespace WebServiceResTEC.Profiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Admin, AdminDto>().ReverseMap();
            
            CreateMap<Dish, DishDto>().ReverseMap();
            
            CreateMap<Menu, MenuDto>().ReverseMap();
            
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }

}