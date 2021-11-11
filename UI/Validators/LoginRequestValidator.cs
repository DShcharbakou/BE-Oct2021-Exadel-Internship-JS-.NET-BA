using FluentValidation;
using UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Validators
{
    public class DeveloperValidator : AbstractValidator<LoginRequestModel>
    {
        public DeveloperValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(12, 40);

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(4, 20);
        }
    }
}
