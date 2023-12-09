using BCShop.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ürün adı max 50 karakter olmalıdır");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ürün adı min 2 karakter olmalıdır");
            RuleFor(x => x.Properties).NotEmpty().WithMessage("Ürün özellikleri boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
        }
    }
}
