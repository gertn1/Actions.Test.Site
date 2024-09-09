using Actions.Test.Site.Domain.Enums;

namespace Actions.Test.Site.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        public RoleType RoleName { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }

}
