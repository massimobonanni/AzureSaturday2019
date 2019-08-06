using System;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace AutoMapper
{
    public static class AutoMapperExtensions
    {

        public static void CreateDtoMapping(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ProductDto, Product>().ReverseMap();
        }

    }
}
