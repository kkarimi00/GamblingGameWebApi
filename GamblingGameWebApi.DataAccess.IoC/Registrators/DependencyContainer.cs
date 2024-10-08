using GamblingGameWebApi.Applications.GambleRequests.Commands;
using GamblingGameWebApi.Applications.GambleRequests.Handlers;
using GamblingGameWebApi.Applications.GambleRequests.Validators;
using GamblingGameWebApi.Applications.Users.Handlers;
using GamblingGameWebApi.Applications.Users.Queries;
using GamblingGameWebApi.DataAccess.Repositories;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;
using GamblingGameWebApi.Entities.Domains.Users;
using Infrastructure.Commands;
using Infrastructure.EntityValidators;
using Infrastructure.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GamblingGameWebApi.DataAccess.IoC.Registrators;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IGamblingGameDbContext, GamblingGameDbContext>();
        services.AddTransient<IUserRepository, UsersRepository>();
        services.AddTransient<IGambleRequestsRepository, GambleRequestsRepository>();
        services.AddTransient<IEntityValidator<GambleRequest>, GambleRequestValidator>();
        services.AddTransient<ICommandHandler<SendRequestCommand, GambleResponse>, SendRequestCommandHandler>();
        services.AddTransient<IQueryHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
    }
}
