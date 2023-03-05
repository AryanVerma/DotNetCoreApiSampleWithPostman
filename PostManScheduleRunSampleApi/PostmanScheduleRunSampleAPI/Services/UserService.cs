using Microsoft.EntityFrameworkCore;
using PostmanScheduleRunSampleAPI.DatabaseContext;
using PostmanScheduleRunSampleAPI.Models;
using System.Numerics;

namespace PostmanScheduleRunSampleAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly UsersDatabaseContext _context;

        public UsersService(UsersDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersModel>> GetUsersList()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<UsersModel> GetUserById(int id) => await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

        public async Task<UsersModel> CreateUser(UsersModel User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<int> UpdateUser(UsersModel User)
        {
            _context.Users.Update(User);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(UsersModel User)
        {
            _context.Users.Remove(User);
            return await _context.SaveChangesAsync();
        }
    }
}
