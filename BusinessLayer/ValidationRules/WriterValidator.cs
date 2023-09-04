using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("ünvan kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("en az 4 karakter olmalı");
            RuleFor(x => x.WriterSurName ).MaximumLength(50).WithMessage("en fazla 50 karakter olmalı");

        }
    }
}
