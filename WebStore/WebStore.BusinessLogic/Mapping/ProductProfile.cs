using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.Domain.Entities;

namespace WebStore.BusinessLogic.Mapping
{
    public class ProductProfile
        : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}