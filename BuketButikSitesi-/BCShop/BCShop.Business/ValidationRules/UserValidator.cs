using BCShop.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.ValidationRules
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x=>x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
			RuleFor(x=>x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
			RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
			RuleFor(x=>x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
			RuleFor(x=>x.Name).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");

		}
	}
}
