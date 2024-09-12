namespace Actions.Test.Site.Domain.Entities
{
    public class UserEntity : BaseEntity 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public RoleEntity Role { get; set; }


       
    }

}
