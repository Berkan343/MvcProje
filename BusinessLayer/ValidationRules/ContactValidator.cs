using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu adını boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("en az 3 karakter olmalı");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("en az 3 karakter olmalı");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("en fazla 50 karakter olmalı");


        }
    }
}
