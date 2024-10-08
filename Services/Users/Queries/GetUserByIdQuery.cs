using Infrastructure.Queries;

namespace GamblingGameWebApi.Applications.Users.Queries;

public class GetUserByIdQuery : IQuery
{
    public int UserId { get; set; }
}
