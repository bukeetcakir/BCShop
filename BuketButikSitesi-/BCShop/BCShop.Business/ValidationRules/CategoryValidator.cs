using BCShop.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.ValidationRules
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
			RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı max 50 karakter olmalıdır");
			RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı min 2 karakter olmalıdır");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
		}
	}
}
