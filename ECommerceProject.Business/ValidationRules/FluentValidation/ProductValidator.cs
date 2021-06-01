using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);

        }

    }
}
