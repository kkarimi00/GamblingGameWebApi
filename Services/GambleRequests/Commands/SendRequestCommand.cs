using GamblingGameWebApi.Entities.Domains.GambleRequests;
using Infrastructure.Commands;

namespace GamblingGameWebApi.Applications.GambleRequests.Commands;

public class SendRequestCommand : ICommand
{
    public GambleRequest gambleRequest; 
}
