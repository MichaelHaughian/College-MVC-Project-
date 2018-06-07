// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 04-09-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 04-10-2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SpeedoModels.Dtos;
using SpeedoModels.Models;

namespace SpeedoModels.App_Start
{
    /// <summary>
    /// Class MappingProfile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();

            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierDto, Supplier>();
        }
    }
}