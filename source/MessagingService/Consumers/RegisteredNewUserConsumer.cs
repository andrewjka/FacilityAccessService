using System.Threading;
using System.Threading.Tasks;
using Domain.UserScope.Actions;
using Domain.UserScope.Services;
using EasyNetQ.AutoSubscribe;

namespace MessagingService.Consumers;

public class RegisteredNewUserConsumer : IConsumeAsync<NewUserRegisteredEvent>
{
    private readonly IUserService _userService;


    public RegisteredNewUserConsumer(IUserService userService)
    {
        _userService = userService;
    }

    [ForTopic("event.user.registered")]
    public async Task ConsumeAsync(NewUserRegisteredEvent message, CancellationToken cancellationToken = new())
    {
        var model = new RegistryUserModel(message.UserId);

        await _userService.RegistryUserAsync(model);
    }
}