using Core.Layer.Dtos;
using Core.Layer.Enums;
using Core.Layer.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Layer;
using Core.Layer.Interfaces;
using Core.Layer.Interfaces.UnitOfWork;
using AutoMapper;
using Core.Layer.Entities;
using System.Linq.Expressions;
using Microsoft.Extensions.Caching.Memory;
using Core.Layer.Interfaces.Repository;

namespace Cache.Layer
{
    public class ProductRedisCache:IProductService
    {
        private const string CacheProductKey = "ProductCache";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;
        public ProductRedisCache(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;

            if (! _memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetAll().Result.ToList());
            }
        }
        public async Task CacheAllProducts()
        {
            _memoryCache.Set(CacheProductKey,await _productRepository.GetAll());

        }
        public async Task<Product> Add(Product product)
        {
            await _productRepository.Add(product);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
            return product;
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public CustomResponseDto<IQueryable<ProductDto>> Search(ECategory category)
        {
            return CustomResponseDto<IQueryable<ProductDto>>.success(200,_mapper.Map<IQueryable<ProductDto>>( _memoryCache.Get<List<Product>>(CacheProductKey).Where(x =>x.Category==category).AsQueryable()));
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }
    }
}
