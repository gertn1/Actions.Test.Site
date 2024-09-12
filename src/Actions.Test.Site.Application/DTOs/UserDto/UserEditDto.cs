
using Actions.Test.Site.Application.DTOs.Base;

namespace Actions.Test.Site.Application.DTOs.UserDto
{
    public class UserEditDto : DtoBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public DateTime? LastLogin { get; set; }

        public UserEditDto(string name, string email, string phone, DateTime birthDate, string password, string address, int roleId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Password = !string.IsNullOrWhiteSpace(password) ? BCrypt.Net.BCrypt.HashPassword(password) : password;
            Address = address;
            RoleId = roleId;
        }
    }
}
