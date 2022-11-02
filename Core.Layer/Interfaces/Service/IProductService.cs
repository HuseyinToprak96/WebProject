using Core.Layer.Dtos;
using Core.Layer.Entities;
using Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Interfaces.Service
{
    public interface IProductService:IService<Product>
    {
        CustomResponseDto<IQueryable<ProductDto>> Search(ECategory category);
    }
}
