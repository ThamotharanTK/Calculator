using Calculator.Application.Exceptions;
using Calculator.Domain.Entities;
using Calculator.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _appDbContext;
        public UserService(AppDBContext context)
        {
            _appDbContext = context;
        }

        public async Task<User> GetByRefreshToken(string token)
        {
            var users = _appDbContext.Users.Where(u => u.RefreshToken == token).ToList();
            if (users==null || users.Count == 0)
            {
                throw new NotFoundException("Invalid refresh token");
            }
            return users[0];
        }

        public async Task<User> LoginCheck(string email, string password)
        {
            var users = _appDbContext.Users.Where(u => u.Email == email && u.Password == password).ToList();
            if (users == null || users.Count == 0)
            {
                throw new NotFoundException("Invalid username or password");
            }
            return users[0];
        }
        public async Task<User> Update(User user)
        {
            //_appDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updatedUser = _appDbContext.Users.Update(user);
            updatedUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}
