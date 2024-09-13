namespace Actions.Test.Site.Infrastructure.Repositories
{
    using global::Actions.Test.Site.Domain.Entities;
    using global::Actions.Test.Site.Domain.Interfaces.Repositories;
    using global::Actions.Test.Site.Infrastructure.Repositories.RepositoryBase;
    using Microsoft.EntityFrameworkCore;

    namespace Actions.Test.Site.Infrastructure.Repositories
    {
        public class UserRepository : RepositoryBase<UserEntity, int>, IUserRepository
        {
            public UserRepository(AppDbContext context) : base(context)
            {
            }
            public async Task<UserEntity?> GetByEmailAsync(string email)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }

            public async Task<UserEntity> GetUserByEmailAsync(string email)
            {
                var user = await _context.Users
                                     .FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                return user;
            }


        }
    }

}
