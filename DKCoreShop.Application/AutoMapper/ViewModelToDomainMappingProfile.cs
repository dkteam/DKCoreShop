using AutoMapper;
using DKCoreShop.Application.ViewModels.Product;
using DKCoreShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c=> new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag, c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription)); 
        }
    }
}
