using Autofac;
using Core.Layer.Interfaces.Repository;
using Core.Layer.Interfaces.Service;
using Repository.Layer.Repositories;
using Service.Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
        }
    }
}
