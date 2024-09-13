using Actions.Test.Site.Application.DTOs.UserDto;
using FluentValidation;

namespace Actions.Test.Site.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email é obrigatório.")
                                .EmailAddress().WithMessage("O email deve ser válido.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("O telefone é obrigatório.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("A data de nascimento é obrigatória.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("A senha é obrigatória.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("O endereço é obrigatório.");
            RuleFor(x => x.RoleType).IsInEnum().WithMessage("O tipo de cargo é inválido.");
        }
    }
}
