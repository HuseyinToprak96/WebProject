using AutoMapper;
using Core.Layer.Dtos;
using Core.Layer.Entities;
using Core.Layer.Enums;
using Core.Layer.Interfaces.Repository;
using Core.Layer.Interfaces.Service;
using Core.Layer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Services
{
    public class ProductService : Service<Product>,IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IGenericRepository<Product> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _productRepository = productRepository;
        }

        public CustomResponseDto<IQueryable<ProductDto>> Search(ECategory category)
        {
            var datas = _productRepository.Search(category);
            return CustomResponseDto<IQueryable<ProductDto>>.success(200,_mapper.Map<IQueryable<ProductDto>>(datas));
        }
    }
}
