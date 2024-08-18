using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public class AddressValidator : AbstractValidator<Address>
  {
    public AddressValidator()
    {
      RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.");
      RuleFor(x => x.Description1).MaximumLength(25).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız.");
      RuleFor(x => x.Description1).MinimumLength(5).WithMessage("En az 5 karakter girilebilir.");

      RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama boş geçemezsiniz.");
      RuleFor(x => x.Description2).MaximumLength(25).WithMessage("En fazla 20 karakter girilebilir.");
      RuleFor(x => x.Description2).MinimumLength(4).WithMessage("En az 3 karakter girilebilir.");

      RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama boş geçilemez");
      RuleFor(x => x.Description3).MaximumLength(25).WithMessage("En fazla 20 karakter girilebilir.");
      RuleFor(x => x.Description3).MinimumLength(4).WithMessage("En az 3 karakter girilebilir.");

      RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.");
      RuleFor(x => x.Description4).MaximumLength(25).WithMessage("En fazla 20 karakter girilebilir.");
      RuleFor(x => x.Description4).MinimumLength(4).WithMessage("En az 3 karakter girilebilir.");
    }
















  }
}
