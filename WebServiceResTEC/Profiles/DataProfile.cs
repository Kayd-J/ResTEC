using AutoMapper;
using WebServiceResTEC.Models;
using WebServiceResTEC.DTOs;

namespace WebServiceResTEC.Profiles
{

    //This class set all the available mapping for the data models of the database.
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<LoginProfile, LoginDto>().ReverseMap();
            
            CreateMap<Chef, ChefDto>().ReverseMap();
            
            CreateMap<Dish, DishDto>().ReverseMap();
            
            CreateMap<Menu, MenuDto>().ReverseMap();
            
            CreateMap<Client, ClientDto>().ReverseMap();
            
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }

}