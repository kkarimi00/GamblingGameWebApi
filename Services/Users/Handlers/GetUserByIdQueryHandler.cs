using GamblingGameWebApi.Applications.Users.Queries;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;
using GamblingGameWebApi.Entities.Domains.Users;
using Infrastructure.Queries;

namespace GamblingGameWebApi.Applications.Users.Handlers;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
{
    public IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> HandleAsync(GetUserByIdQuery query)
    {
        return await _userRepository.GetById(query.UserId);
    }
}
