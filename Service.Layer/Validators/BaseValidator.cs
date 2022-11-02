using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public string NotFound { get; } = "{PropertyName} bulunamadı!";
        public string Selected { get; } = "Bir Seçim Yapınız!";
        public string maxMessage { get; } = "En fazla {MaxLength} karakter alabilir!";
        public string minMessage { get; } = "En az {MinLength} karakter alabilir!";
        public string Between { get; } = "{From} ile {To} aralığında olmalıdır!";
        public string requiredMessage { get; } = "{PropertyName} boş geçilemez!";
        public string possitiveInt { get; } = "{PropertyName} 0 dan büyük olmalıdır.";
    }
}
