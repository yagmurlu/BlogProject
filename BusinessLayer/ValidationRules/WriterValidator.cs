using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage
                ("Yazar Adı Boş Geçilemez!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage
                ("Yazar Soyadı Boş Geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage
                ("Mail Boş Geçilemez!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage
                ("Şifre Boş Geçilemez!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage
                ("LÜtfen En Az İki Karakter Girişi Yapınız!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage
                ("LÜtfen En Az İki Karakter Girişi Yapınız!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage
                ("LÜtfen En Fazla Elli Karakterlik Veri Girişi Yapınız!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage
               ("LÜtfen En Fazla Elli Karakterlik Veri Girişi Yapınız!");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage
                ("En az 1 büyük harf, en az 1 küçük harf, en az 1 sayı bulunmalıdır.");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {

                return false;
            }
        }
    }
}
