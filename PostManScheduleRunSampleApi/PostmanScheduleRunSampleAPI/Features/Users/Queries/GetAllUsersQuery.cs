using MediatR;
using PostmanScheduleRunSampleAPI.Models;
using PostmanScheduleRunSampleAPI.Services;
using System.Numerics;

namespace PostmanScheduleRunSampleAPI.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UsersModel>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UsersModel>>
        {
            private readonly IUsersService _usersService;

            public GetAllUsersQueryHandler(IUsersService usersService)
            {
                _usersService = usersService;
            }

            public async Task<IEnumerable<UsersModel>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var  result= await _usersService.GetUsersList();
                return result;
            }
        }
    }
}
