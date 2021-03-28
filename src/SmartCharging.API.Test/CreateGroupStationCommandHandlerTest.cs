using FakeItEasy;
using NUnit.Framework;
using SmartCharging.Application.Commands;
using SmartCharging.Application.Queries;
using SmartCharging.Domain;
using System.Threading.Tasks;

namespace SmartCharging.API.Test
{
    /// <summary>
    /// I may cover all possibles cenaries here. but I guess this should be enough for this test. 
    /// </summary>
    public class Tests
    {
        private FactoryCreateGroup _factoryCreateGroup;
        private IGroupRepository _groupRepository;

        [SetUp]
        public void Setup()
        {
            _factoryCreateGroup = new FactoryCreateGroup();

            _groupRepository = A.Fake<IGroupRepository>();
        }

        [Test]
        public async Task Should_CreateGroupStationCommandHandler()
        {
            var groupStation = _factoryCreateGroup.CreateGroupStationInputModel();

            A.CallTo(() => _groupRepository.Add(A<GroupStation>.Ignored)).Returns(Task.CompletedTask);

            var commandHandler = new CreateGroupStationCommandHandler(_groupRepository);

            var result = await commandHandler.Execute(groupStation);

            Assert.IsTrue(result);
            Assert.AreEqual("Group has been added", commandHandler.HandlerMessage);
            Assert.Pass();
        }
    }
}