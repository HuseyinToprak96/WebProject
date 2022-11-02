using Core.Layer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Service.Layer.Validators
{
    public class CreateOrderRequestValidator: BaseValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage(requiredMessage).NotNull().WithMessage(requiredMessage);
            RuleFor(x =>x.CustomerEmail).NotEmpty().WithMessage(requiredMessage).NotNull().WithMessage(requiredMessage);
            RuleFor(x => x.CustomerGSM).NotEmpty().WithMessage(requiredMessage).NotNull().WithMessage(requiredMessage);
        }
    }
}
