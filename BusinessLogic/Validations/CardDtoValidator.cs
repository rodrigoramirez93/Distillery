using BusinessLogic.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validations
{
    public class CardDtoValidator : AbstractValidator<CardDto>
    {
        public CardDtoValidator()
        {
            RuleFor(x => x.Digits).NotEmpty().WithMessage("Please provide card digits");
            RuleFor(x => x.Digits).Length(15).WithMessage("Invalid digits length");
            RuleFor(x => x.Digits).Must(x => long.TryParse(x, out long i)).WithMessage("Please provide only numbers");
        }
    }
}