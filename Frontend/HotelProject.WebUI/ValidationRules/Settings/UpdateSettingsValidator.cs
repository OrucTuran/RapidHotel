using FluentValidation;
using HotelProject.WebUI.Models.Setting;

namespace HotelProject.WebUI.ValidationRules.Settings
{
    public class UpdateSettingsValidator : AbstractValidator<UserEditViewModel>
    {
        public UpdateSettingsValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Adınız boş olamaz.")
                .Length(2, 50).WithMessage("Adınız 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyadınız boş olamaz.")
                .Length(2, 50).WithMessage("Soyadınız 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .Length(4, 20).WithMessage("Kullanıcı adınız 4 ile 20 karakter arasında olmalıdır.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.");

            RuleFor(x => x.ConfrimPassword)
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor.");
        }
    }
}
