using DKCoreShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public EFUnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
