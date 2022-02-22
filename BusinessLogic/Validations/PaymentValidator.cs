using BusinessLogic.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validations
{
    public class PaymentValidator : AbstractValidator<PaymentDto>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.PaymentAmount).GreaterThan(0).WithMessage("Payment amount has to be greater than zero");
        }
    }
}