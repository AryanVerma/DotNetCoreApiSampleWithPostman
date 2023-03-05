using PostmanScheduleRunSampleAPI.Models;
using System.Numerics;

namespace PostmanScheduleRunSampleAPI.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersModel>> GetUsersList();
        Task<UsersModel> GetUserById(int id);
        Task<UsersModel> CreateUser(UsersModel user);
        Task<int> UpdateUser(UsersModel user);
        Task<int> DeleteUser(UsersModel user);
    }
}
