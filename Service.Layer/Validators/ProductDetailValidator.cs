using Core.Layer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Service.Layer.Validators
{
    public class ProductDetailValidator:BaseValidator<ProductDetail>
    {
        public ProductDetailValidator()
        {
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage(requiredMessage).NotNull().WithMessage(requiredMessage);
            RuleFor(x => x.Amount).InclusiveBetween(0, int.MaxValue).WithMessage(Between);
        }
    }
}
