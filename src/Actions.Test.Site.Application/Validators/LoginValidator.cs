using Actions.Test.Site.Application.DTOs.LoginDto;
using FluentValidation;

namespace Actions.Test.Site.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email é obrigatório.")
                                .EmailAddress().WithMessage("O email deve ser válido.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("A senha é obrigatória.");
        }
    }
}
