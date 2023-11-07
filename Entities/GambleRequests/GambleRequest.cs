using GamblingGameWebApi.Entities.Domains.Users;

namespace GamblingGameWebApi.Entities.Domains.GambleRequests;

public class GambleRequest
{
    public int Id { get; set; }
    public int InvestPoint { get; set; }
    public int SelectedNumber { get; set; }
    public ResultState ResultState { get; set; }
    public int ResultPoints { get; set; }
    public User User { get; set; }
}
