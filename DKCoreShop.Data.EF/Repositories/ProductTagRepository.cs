using DKCoreShop.Data.Entities;
using DKCoreShop.Data.IRepositories;

namespace DKCoreShop.Data.EF.Repositories
{
    public class ProductTagRepository : EFRepository<ProductTag, int>, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}