using NUnit.Framework;
using WorldOfTank.Class.Model;

namespace WorldOfTank.Test
{
    [TestFixture]
    class TestTank
    {
        private Tank _tank;

        [SetUp]
        public void Setup()
        {
            _tank = new Tank(Properties.Resources.Tank_A);
        }

        [Test]
        public void TestContructor()
        {
            Assert.AreEqual(_tank.Position.X, 0);
            Assert.AreEqual(_tank.Position.Y, 0);
            Assert.AreEqual(_tank.Direction, 0);
        }

        [Test]
        public void TestRotation()
        {
            float dir = _tank.Direction;
            _tank.RotateRight(80);
            Assert.AreEqual(_tank.Direction, dir + 80);
        }
    }
}
