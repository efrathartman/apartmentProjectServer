using AutoMapper;
using Common.Dtos;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<Response, ResponseDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
