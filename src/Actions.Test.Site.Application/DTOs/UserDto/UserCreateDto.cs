using Actions.Test.Site.Domain.Enums;

namespace Actions.Test.Site.Application.DTOs.UserDto
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public RoleType RoleType { get; set; }
        public DateTime? LastLogin { get; set; }

        public UserCreateDto(string name, string email, string phone, DateTime birthDate, string password, string address, RoleType roleType)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Password = BCrypt.Net.BCrypt.HashPassword(password); 
            Address = address;
            RoleType = roleType;
        }
    }
}
