using Core.Layer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Service.Layer.Validators
{
    public class ProductValidator:BaseValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage(requiredMessage).NotNull().WithMessage(requiredMessage).MaximumLength(500).WithMessage(maxMessage);
            RuleFor(x => x.Unit).InclusiveBetween(1, int.MaxValue).WithMessage(possitiveInt);
        }
    }
}
