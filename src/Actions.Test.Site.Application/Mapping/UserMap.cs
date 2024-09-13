using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Domain.Entities;


// Posso usar AutoMapper  
namespace YourNamespace.Application.Map
{
    public static class UserMap
    {

        public static UserEntity MapToEntity(this UserCreateDto dto)
        {
            return new UserEntity
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate,
                Password = dto.Password,
                Address = dto.Address,
                Role = dto.RoleType
            };  
        }
        public static void MapUpdateEntity(this UserEditDto dto, UserEntity entity)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.BirthDate = dto.BirthDate;
            entity.Password = dto.Password;
            entity.Address = dto.Address;
            entity.Role = dto.RoleType;
        }
    }
}
