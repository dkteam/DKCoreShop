using DKCoreShop.Data.Entities;
using DKCoreShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Data.EF.Repositories
{
    public class ProductRepository : EFRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
