using MediatR;
using PostmanScheduleRunSampleAPI.Models;
using PostmanScheduleRunSampleAPI.Services;

namespace PostmanScheduleRunSampleAPI.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {


            private readonly IUsersService _usersService;
            public UpdateUserCommandHandler(IUsersService usersService)
            {
                _usersService = usersService;
            }

            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var result = await _usersService.GetUserById((int)command.Id);
                if (result == null)
                    return default;


                result.EnglishName = command.EnglishName;
                result.ArabicName = command.ArabicName;
                return await _usersService.UpdateUser(result);
            }
        }
    }
}
