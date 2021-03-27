using NUnit.Framework;

namespace SmartCharging.API.Test
{
    public class Tests
    {
        private FactoryCreateGroup _factoryCreateGroup;

        [SetUp]
        public void Setup()
        {
            _factoryCreateGroup = new FactoryCreateGroup();
        }

        [Test]
        public void Test1()
        {
            var groupStation = _factoryCreateGroup.CreateGroupStation();


            Assert.Pass();
        }
    }
}