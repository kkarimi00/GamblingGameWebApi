using GamblingGameWebApi.Applications.GambleRequests.Commands;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.GambleRequests.Dtos;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;
using Infrastructure.Commands;

namespace GamblingGameWebApi.Applications.GambleRequests.Handlers;

public class SendRequestCommandHandler : ICommandHandler<SendRequestCommand, GambleResponse>
{
    private readonly IGambleRequestsRepository _gambleRequestsRepository;
    private readonly IUserRepository _userRepository;

    public SendRequestCommandHandler
        (IGambleRequestsRepository gambleRequestsRepository,
        IUserRepository userRepository)
    {
        _gambleRequestsRepository = gambleRequestsRepository;
        _userRepository = userRepository;
    }

    public async Task<GambleResponse> HandleAsync(SendRequestCommand command)
    {

        GambleResponse gambleResponse = CalculateResponse(command.gambleRequest);

        await AddGambleRequestAsync(command, gambleResponse);

        await UpdateUserAsync(command, gambleResponse);

        gambleResponse.AccountPoint = command.gambleRequest.User.CurrentPoint;

        return gambleResponse;

    }

    private async Task UpdateUserAsync(SendRequestCommand command, GambleResponse gambleResponse)
    {
        command.gambleRequest.User.CurrentPoint = (command.gambleRequest.User.InitialPoint + gambleResponse.ResultPoints);
        await _userRepository.Update(command.gambleRequest.User);
    }

    private async Task AddGambleRequestAsync(SendRequestCommand command, GambleResponse gambleResponse)
    {
        command.gambleRequest.ResultState = gambleResponse.ResultState;
        command.gambleRequest.ResultPoints = gambleResponse.ResultPoints;
        await _gambleRequestsRepository.Add(command.gambleRequest);
    }

    public GambleResponse CalculateResponse(GambleRequest gambleRequest)
    {
        Random random = new Random();
        int num = random.Next(1, 10);
        GambleResponse gambleResponseDto = new();

        if (num == gambleRequest.SelectedNumber)
        {
            gambleResponseDto.ResultState = ResultState.Won;
            gambleResponseDto.ResultPoints = (gambleRequest.InvestPoint * 9);
        }
        else
        {
            gambleResponseDto.ResultState = ResultState.Lost;
            gambleResponseDto.ResultPoints = gambleRequest.InvestPoint;
        }

        return gambleResponseDto;
    }
}
