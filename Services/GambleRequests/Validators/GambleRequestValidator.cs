using GamblingGameWebApi.Entities.Domains.GambleRequests;
using Infrastructure.EntityValidators;

namespace GamblingGameWebApi.Applications.GambleRequests.Validators;

public class GambleRequestValidator : EntityValidator<GambleRequest>
{
    protected override void ValidateRequiredProperties()
    {
        ValidateRequiredInvestPoint();

    }

    protected void ValidateRequiredInvestPoint()
    {

    }
}
