using BCShop.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.ValidationRules
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Details1).NotEmpty().WithMessage("Detaylar1 adı boş geçilemez");
            RuleFor(x => x.Details1).MaximumLength(150).WithMessage("Detaylar1 adı max 150 karakter olmalıdır");
            RuleFor(x => x.Details1).MinimumLength(2).WithMessage("DEtaylar1 adı min 2 karakter olmalıdır");
            RuleFor(x => x.Details2).NotEmpty().WithMessage("Detaylar2 adı boş geçilemez");
            RuleFor(x => x.Details2).MaximumLength(500).WithMessage("Detaylar2 adı max 150 karakter olmalıdır");
            RuleFor(x => x.Details2).MinimumLength(2).WithMessage("DEtaylar2 adı min 2 karakter olmalıdır");
        }
    }
}
