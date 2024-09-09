using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services.Base;
using Actions.Test.Site.Domain.Entities;

namespace Actions.Test.Site.Application.Interfaces.Services
{
    public interface IUserService : IBaseService<UserEntity, UserCreationDto, UserEditDto, int>
    {

    }
}
