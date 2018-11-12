using DKCoreShop.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Application.Interfaces
{
    public interface IProductService: IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}
