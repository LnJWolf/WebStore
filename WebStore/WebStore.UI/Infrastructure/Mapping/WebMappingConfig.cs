using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebStore.Domain.Entities;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.UI.Infrastructure.Mapping
{
    public class WebMappingConfig
        : Profile
    {
        public WebMappingConfig()
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}