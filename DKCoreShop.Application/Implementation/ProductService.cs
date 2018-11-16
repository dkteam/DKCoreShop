using AutoMapper;
using AutoMapper.QueryableExtensions;
using DKCoreShop.Application.Interfaces;
using DKCoreShop.Application.ViewModels.Product;
using DKCoreShop.Data.Entities;
using DKCoreShop.Data.Enums;
using DKCoreShop.Data.IRepositories;
using DKCoreShop.Infrastructure.Interfaces;
using DKCoreShop.Utilities.Constants;
using DKCoreShop.Utilities.Dtos;
using DKCoreShop.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DKCoreShop.Application.Implementation
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, ITagRepository tagRepository, IProductTagRepository productTagRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
        }

        public ProductViewModel Add(ProductViewModel productVm)
        {         
            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                List<ProductTag> productTags = new List<ProductTag>();
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
                var product = Mapper.Map<ProductViewModel, Product>(productVm);
                foreach (var productTag in productTags)
                {
                    product.ProductTags.Add(productTag);
                }
                _productRepository.Add(product);

            }
            else
            {
                _productRepository.Add(product);
            }
            return productVm;
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }

        public PageResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            int totalRow = query.Count();
            query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();

            var paginationSet = new PageResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public ProductViewModel GetById(int id)
        {
            return Mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = t;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productVm.Id).ToList());
                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                    //_productTagRepository.Add(productTag);
                }
            }

            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Update(product);
        }
    }
}