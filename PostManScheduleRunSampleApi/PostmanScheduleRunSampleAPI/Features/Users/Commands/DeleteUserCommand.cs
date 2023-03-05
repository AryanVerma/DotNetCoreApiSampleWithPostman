using MediatR;
using PostmanScheduleRunSampleAPI.Services;

namespace PostmanScheduleRunSampleAPI.Features.Users.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
        {
            private readonly IUsersService _userService;

            public DeleteUserCommandHandler(IUsersService userService)
            {
                _userService = userService;
            }

            public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userService.GetUserById(command.Id);
                if (user == null)
                    return default;

                return await _userService.DeleteUser(user);
            }
        }

    }
}
