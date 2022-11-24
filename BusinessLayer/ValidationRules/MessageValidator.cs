using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Meassage>
    {
        public MessageValidator()
        {

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage(" Alıcı adresini boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage(" Konuyu  boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage(" Mesajı  boş geçilemez");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girişi yapınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen 3 karakterden az deger girişi yapmayınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla deger girişi yapmayınız");
        }
    }
}
