using Actions.Test.Site.Domain.Enums;

namespace Actions.Test.Site.Domain.Entities
{
    public class RoleEntity
    {

        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }

}
