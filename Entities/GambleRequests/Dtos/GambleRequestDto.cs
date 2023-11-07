using GamblingGameWebApi.Entities.Domains.Users;

namespace GamblingGameWebApi.Entities.Domains.GambleRequests;

public class GambleRequestDto
{
    public int InvestPoint { get; set; }
    public int SelectedNumber { get; set; }
    public User User { get; set; }
}
