using DKCoreShop.Data.Entities;
using DKCoreShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}
