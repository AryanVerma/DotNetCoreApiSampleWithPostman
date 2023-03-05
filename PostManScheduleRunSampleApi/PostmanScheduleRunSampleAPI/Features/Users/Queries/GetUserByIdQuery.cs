using MediatR;
using PostmanScheduleRunSampleAPI.Models;
using PostmanScheduleRunSampleAPI.Services;
using System.Numerics;

namespace PostmanScheduleRunSampleAPI.Features.Users.Queries
{
     
    public class GetUserByIdQuery : IRequest<UsersModel>
    {
        public int Id { get; set; }

        public class GetPlayerByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UsersModel>
        {
            private readonly IUsersService _usersService;

            public GetPlayerByIdQueryHandler(IUsersService usersService)
            {
                _usersService = usersService;
            }

            public async Task<UsersModel> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                return await _usersService.GetUserById(query.Id);
            }
        }
    }
}
