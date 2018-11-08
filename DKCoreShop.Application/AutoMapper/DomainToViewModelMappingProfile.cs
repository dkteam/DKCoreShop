using AutoMapper;
using DKCoreShop.Application.ViewModels.Product;
using DKCoreShop.Application.ViewModels.System;
using DKCoreShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
        }
    }
}
