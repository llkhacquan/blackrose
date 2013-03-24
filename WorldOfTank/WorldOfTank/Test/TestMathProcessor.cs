using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NUnit.Framework;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Test
{
    [TestFixture]
    class TestMathProcessor
    {
        PointF p1, p2, p3, p4, p5, p6;

        [SetUp]
        public void Setup()
        {
            p1 = new PointF(1, 1);
            p2 = new PointF(2, 2);
            p3 = new PointF(3, 3);
            p4 = new PointF(3, 4);
            p5 = new PointF(4, 3);
            p6 = new PointF(3, 2);
        }

        [Test]
        public void TestCCWCheck()
        {
            Assert.AreEqual(MathProcessor.CheckCCW(p1, p2, p3), 0);
            Assert.AreEqual(MathProcessor.CheckCCW(p1, p2, p4), 1);
            Assert.AreEqual(MathProcessor.CheckCCW(p1, p2, p5), -1);
            Assert.AreEqual(MathProcessor.CheckCCW(p4, p5, p3), -1);
        }

        [Test]
        public void TestLineIntersectionCheck()
        {
            Assert.AreEqual(MathProcessor.LineIntersectionCheck(p1, p3, p4, p6), false);
            Assert.AreEqual(MathProcessor.LineIntersectionCheck(p1, p6, p2, p5), false);
            Assert.AreEqual(MathProcessor.LineIntersectionCheck(p2, p5, p4, p6), true);
        }

        [Test]
        public void TestCalDegreePoint()
        {
            Assert.AreEqual(MathProcessor.CalPointAngle(p4, p5), 45);
            Assert.AreEqual(MathProcessor.CalPointAngle(p3, p5), 90);
            Assert.AreEqual(MathProcessor.CalPointAngle(p5, p3), -90);
            Assert.AreEqual(MathProcessor.CalPointAngle(p3, p6), 0);
            Assert.AreEqual(MathProcessor.CalPointAngle(p3, p2), -45);
            Assert.AreEqual(MathProcessor.CalPointAngle(p2, p3), 135);
            Assert.AreEqual(MathProcessor.CalPointAngle(p6, p4), 180);
        }

        [Test]
        public void TestCalPointRotatation()
        {
            Assert.AreEqual(MathProcessor.CalPointRotatation(p3, p6, 90), p5);
            Assert.AreEqual(MathProcessor.CalPointRotatation(p3, p5, -90), p6);
        }
    }
}
