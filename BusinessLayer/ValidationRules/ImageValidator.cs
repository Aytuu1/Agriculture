using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public class ImageValidator : AbstractValidator<Image>
  {
    public ImageValidator()
    {
      RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık kısmı boş geçilemez");
      RuleFor(x => x.Title).MinimumLength(3).WithMessage("Minumum 3 karakter girebilirsiniz.");
      RuleFor(x => x.Title).MaximumLength(20).WithMessage("Maximum 20 karakter girebilirsiniz.");
      RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
      RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Yolu Boş Geçilemez");
      RuleFor(x => x.Description).MaximumLength(50).WithMessage("Açıklama alanı maximum 30 karakter olabilir.");
      RuleFor(x => x.Description).MinimumLength(6).WithMessage("Açıklama alanı minumum 6 karakter olabilir.");
    }


















  }
}
