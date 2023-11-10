namespace GamblingGameWebApi.Entities.Domains.GambleRequests;

public class GambleResponse
{
    public ResultState ResultState { get; set; }
    public int ResultPoints { get; set; }
    public int AccountPoint { get; set; }
}
