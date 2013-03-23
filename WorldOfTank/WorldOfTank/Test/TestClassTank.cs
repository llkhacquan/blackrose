using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WorldOfTank.Class.Model;

namespace WorldOfTank.Test
{
    [TestFixture]
    class TestTank
    {
        private Tank tank;

        [SetUp]
        public void Setup()
        {
            tank = new Tank(WorldOfTank.Properties.Resources.Tank_A);
        }

        [Test]
        public void TestContructor()
        {
            Assert.AreEqual(tank.Position.X, 0);
            Assert.AreEqual(tank.Position.Y, 0);
            Assert.AreEqual(tank.Direction, 0);
            Assert.AreEqual(tank.Anchor.X, 0);
            Assert.AreEqual(tank.Anchor.Y, 0);
        }

        [Test]
        public void TestRotation()
        {
            float dir = tank.Direction;
            tank.RotateRight(80);
            Assert.AreEqual(tank.Direction, dir + 80);
        }
    }
}
