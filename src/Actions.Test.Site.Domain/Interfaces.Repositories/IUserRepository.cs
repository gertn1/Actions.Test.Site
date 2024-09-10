using Actions.Test.Site.Domain.Entities;

namespace Actions.Test.Site.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<UserEntity, int>
    {

        Task<UserEntity?> GetByEmailAsync(string email);
     
        Task<UserEntity> GetUserByEmailAsync(string email);
    }
}
