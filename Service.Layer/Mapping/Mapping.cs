using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Layer;
using Core.Layer.Entities;
using Core.Layer.Dtos;

namespace Service.Layer.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
             
        }
    }
}
