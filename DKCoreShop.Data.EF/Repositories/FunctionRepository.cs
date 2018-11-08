using DKCoreShop.Data.Entities;
using DKCoreShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
