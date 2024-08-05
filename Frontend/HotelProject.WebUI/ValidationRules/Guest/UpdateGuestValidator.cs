using FluentValidation;
using HotelProject.WebUI.DTOs.GuestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ValidationRules.Guest
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDTO>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("İsim alanı boş geçilemez.")
               .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.")
               .MaximumLength(15).WithMessage("Lütfen en fazla 15 karakter veri girişi yapınız.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız.")
                .MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş geçilemez.")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.")
                .MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız.");
        }
    }
}
