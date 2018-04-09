using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SpeedoModels.Dtos;
using SpeedoModels.Models;

namespace SpeedoModels.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();

            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierDto, Supplier>();
        }
    }
}