using Actions.Test.Site.Domain.Enums;

namespace Actions.Test.Site.Domain.Entities
{
    public class UserEntity : BaseEntity 
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Password { get; set; }
        public string? Address { get; set; }
        public RoleType Role { get; set; }
        public DateTime? LastLogin { get; set; }
       
    }

}
