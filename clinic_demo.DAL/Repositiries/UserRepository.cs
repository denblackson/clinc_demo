using clinic_demo.DAL.Interfaces;
using clinic_demo.Domain.Entity;

namespace clinic_demo.DAL.Repositiries
{
    public class UserRepository : IBaseRepository<UserEntity>
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }


        public async Task Create(UserEntity entity)
        {
            await _appDbContext.Users.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<UserEntity> GetAll()
        {
            return _appDbContext.Users;
        }

        public async Task Delete(UserEntity entity)
        {
            _appDbContext.Users.Remove(entity);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<UserEntity> Update(UserEntity entity)
        {
            _appDbContext.Users.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
