using GamblingGameWebApi.Applications.GambleRequests.Commands;
using GamblingGameWebApi.Applications.GambleRequests.Handlers;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.GambleRequests;
using GamblingGameWebApi.Entities.Domains.RepositoryContracts.Users;
using GamblingGameWebApi.Entities.Domains.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GamblingGameWebApi.Applications.UnitTests.GambleRequests.Commands
{
    [TestClass]
    public class SendRequestCommandHandlerTests
    {
        private SendRequestCommand _command;
        private SendRequestCommandHandler _commandHandler;
        private IGambleRequestsRepository _gambleRequestsRepositoryMock;
        private IUserRepository _userRepositoryMock;

        [TestInitialize]
        public void InitializeTest()
        {
            InitialDependencies();
            CreateValidCommand();
            CreateCommandHandler();
            SetupDependencies();
        }

        private void InitialDependencies()
        {
            _gambleRequestsRepositoryMock = Substitute.For<IGambleRequestsRepository>();
            _userRepositoryMock = Substitute.For<IUserRepository>();
        }

        private void SetupDependencies()
        {
            _userRepositoryMock.GetById(default).ReturnsForAnyArgs(_ => new User
            {
                CurrentPoint = 1,
                Id = 1,
                InitialPoint = 1,
            });
        }

        private void CreateCommandHandler()
        {
            _commandHandler = new SendRequestCommandHandler(_gambleRequestsRepositoryMock, _userRepositoryMock);
        }

        private void CreateValidCommand()
        {
            _command = new SendRequestCommand()
            {
                gambleRequest = new Entities.Domains.GambleRequests.GambleRequest
                {
                    InvestPoint = 1,
                    SelectedNumber = 2,
                    UserId = 1
                }
            };
        }

        [TestMethod]
        public async Task HandleAsync_CommandIsValid_UserRepositoryGetByIdIsCalled()
        {
            await _commandHandler.HandleAsync(_command);

            await _userRepositoryMock.Received(1).GetById(1);
        }

        [TestMethod]
        public async Task HandleAsync_CommandIsValid_UserRepositoryUpdateIsCalled()
        {
            await _commandHandler.HandleAsync(_command);

            await _userRepositoryMock.Received(1).Update(Arg.Is<User>(c => c.Id == _command.gambleRequest.UserId));
        }

        [TestMethod]
        public async Task HandleAsync_CommandIsValid_GambleRequestRepositoryIsCalled()
        {
            await _commandHandler.HandleAsync(_command);

            await _gambleRequestsRepositoryMock.Received(1).Add(Arg.Is<GambleRequest>(c => c.UserId == _command.gambleRequest.UserId));
        }
    }
}
