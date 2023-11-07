using GamblingGameWebApi.Applications.GambleRequests.Commands;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;
using Infrastructure.Commands;

namespace GamblingGameWebApi.Applications.GambleRequests.Handlers;

public class SendRequestCommandHandler : ICommandHandler<SendRequestCommand>
{
    private readonly IGambleRequestsRepository _gambleRequestsRepository;

    public SendRequestCommandHandler(IGambleRequestsRepository gambleRequestsRepository)
    {
        _gambleRequestsRepository = gambleRequestsRepository;
    }

    public Task HandleAsync(SendRequestCommand command)
    {
        _gambleRequestsRepository.Add(command.gambleRequestDto);
    }
}
