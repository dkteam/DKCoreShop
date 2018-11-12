using DKCoreShop.Application.ViewModels.Product;
using DKCoreShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKCoreShop.Application.Interfaces
{
    public interface IProductService: IDisposable
    {
        List<ProductViewModel> GetAll();
        PageResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
    }
}
