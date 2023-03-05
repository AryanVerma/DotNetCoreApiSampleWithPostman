using MediatR;
using PostmanScheduleRunSampleAPI.Features.Users.Queries;
using PostmanScheduleRunSampleAPI.Models;
using PostmanScheduleRunSampleAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Numerics;

namespace PostmanScheduleRunSampleAPI.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<UsersModel>
    {
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UsersModel>
        {
            

            private readonly IUsersService _usersService;
            public CreateUserCommandHandler(IUsersService usersService)
            {
                _usersService = usersService;
            }

            public async Task<UsersModel> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new UsersModel()
                {
                    UserId = 0,
                    EnglishName = command.EnglishName,
                    ArabicName = command.ArabicName
                };
                return await _usersService.CreateUser(user);
            }
        }
    }
}
