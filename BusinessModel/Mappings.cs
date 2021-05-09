using AutoMapper;
using BusinessModel.Models;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel
{
    public class Mappings : Profile
    {
        public Mappings()
        {            
            CreateMap<Customer, CustomerDTO>()
             .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(source => source.CategoryId));
            CreateMap<CategoryDTO, Category>();              
            CreateMap<CustomerDTO, Customer>()
              .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(source => source.CategoryId));
            CreateMap<Category, CategoryDTO>();            
            CreateMap<List<Customer>, List<CustomerDTO>>();
            CreateMap<List<CustomerDTO>, List<Customer>>();
        }
    }
}
