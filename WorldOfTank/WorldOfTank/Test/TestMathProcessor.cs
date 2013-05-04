using System.Drawing;
using NUnit.Framework;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Test
{
    [TestFixture]
    class TestMathProcessor
    {
        PointF _p1, _p2, _p3, _p4, _p5, _p6;

        [SetUp]
        public void Setup()
        {
            _p1 = new PointF(1, 1);
            _p2 = new PointF(2, 2);
            _p3 = new PointF(3, 3);
            _p4 = new PointF(3, 4);
            _p5 = new PointF(4, 3);
            _p6 = new PointF(3, 2);
        }

        [Test]
        public void TestCounterClockWise()
        {
            Assert.AreEqual(MathProcessor.CounterClockWise(_p1, _p2, _p3), 0);
            Assert.AreEqual(MathProcessor.CounterClockWise(_p1, _p2, _p4), 1);
            Assert.AreEqual(MathProcessor.CounterClockWise(_p1, _p2, _p5), -1);
            Assert.AreEqual(MathProcessor.CounterClockWise(_p4, _p5, _p3), -1);
        }

        [Test]
        public void TestLineIntersectionCheck()
        {
            Assert.AreEqual(MathProcessor.LineIntersectionCheck(_p1, _p3, _p4, _p6), false);
            Assert.AreEqual(MathProcessor.LineIntersectionCheck(_p1, _p6, _p2, _p5), false);
            Assert.AreEqual(MathProcessor.LineIntersectionCheck(_p2, _p5, _p4, _p6), true);
        }

        [Test]
        public void TestCalDegreePoint()
        {
            Assert.AreEqual(MathProcessor.CalPointAngle(_p4, _p5), 45);
            Assert.AreEqual(MathProcessor.CalPointAngle(_p3, _p5), 90);
            Assert.AreEqual(MathProcessor.CalPointAngle(_p5, _p3), -90);
            Assert.AreEqual(MathProcessor.CalPointAngle(_p3, _p6), 0);
            Assert.AreEqual(MathProcessor.CalPointAngle(_p3, _p2), -45);
            Assert.AreEqual(MathProcessor.CalPointAngle(_p2, _p3), 135);
            Assert.AreEqual(MathProcessor.CalPointAngle(_p6, _p4), 180);
        }

        [Test]
        public void TestCalDifferentAngle()
        {
            Assert.AreEqual(MathProcessor.CalDifferentAngle(20, 40), 20);
            Assert.AreEqual(MathProcessor.CalDifferentAngle(20, 500), 120);
            Assert.AreEqual(MathProcessor.CalDifferentAngle(400, 10), -30);
            Assert.AreEqual(MathProcessor.CalDifferentAngle(600, 50), 170);
        }
    }
}
