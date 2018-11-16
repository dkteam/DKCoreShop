using DKCoreShop.Data.Entities;
using DKCoreShop.Data.IRepositories;

namespace DKCoreShop.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}