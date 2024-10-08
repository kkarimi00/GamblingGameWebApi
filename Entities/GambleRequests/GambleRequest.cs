using GamblingGameWebApi.Entities.Domains.Users;
using Infrastructure.Entities;

namespace GamblingGameWebApi.Entities.Domains.GambleRequests;

public class GambleRequest : Entity
{
    public int InvestPoint { get; set; }
    public int SelectedNumber { get; set; }
    public ResultState ResultState { get; set; }
    public int ResultPoints { get; set; }
    public int UserId { get; set; }
}
