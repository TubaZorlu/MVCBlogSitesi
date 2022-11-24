﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Minumum 2 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Maksimum 50 karakter giriniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Minumum 2 karakter giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Maksimum 50karakter giriniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage(" Unvan kısmını boş geçemezsiniz");
        }
    }
}
