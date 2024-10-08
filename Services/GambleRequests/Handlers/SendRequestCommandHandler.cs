using GamblingGameWebApi.Applications.GambleRequests.Commands;
using GamblingGameWebApi.Applications.Users.Queries;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.GambleRequests.Dtos;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;
using GamblingGameWebApi.Entities.Domains.Users;
using Infrastructure.Commands;

namespace GamblingGameWebApi.Applications.GambleRequests.Handlers;

public class SendRequestCommandHandler : ICommandHandler<SendRequestCommand, GambleResponse>
{
    private readonly IGambleRequestsRepository _gambleRequestsRepository;
    private readonly IUserRepository _userRepository;

    private SendRequestCommand _command;
    private User _user;

    public SendRequestCommandHandler
        (IGambleRequestsRepository gambleRequestsRepository,
        IUserRepository userRepository)
    {
        _gambleRequestsRepository = gambleRequestsRepository;
        _userRepository = userRepository;
    }

    public async Task<GambleResponse> HandleAsync(SendRequestCommand command)
    {
        _command = command;
        _user = await GetUserAsync();
        GambleResponse gambleResponse = CalculateResponse(_command.gambleRequest);

        await AddGambleRequestAsync(gambleResponse);

        await UpdateUserAsync(gambleResponse);

        gambleResponse.AccountPoint = _user.CurrentPoint;

        return gambleResponse;

    }

    private async Task<User> GetUserAsync()
    {
        return await _userRepository.GetById(_command.gambleRequest.UserId);
    }

    private async Task UpdateUserAsync(GambleResponse gambleResponse)
    {
        _user.CurrentPoint = (_user.InitialPoint + gambleResponse.ResultPoints);

        await _userRepository.Update(_user);
    }

    private async Task AddGambleRequestAsync(GambleResponse gambleResponse)
    {
        GambleRequest gambleRequest = new()
        {
            ResultPoints = gambleResponse.ResultPoints,
            ResultState = gambleResponse.ResultState,
            UserId = _user.Id
        };

        await _gambleRequestsRepository.Add(gambleRequest);
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
