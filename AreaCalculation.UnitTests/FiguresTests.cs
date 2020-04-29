using System;
using NUnit.Framework;

namespace AreaCalculation.UnitTests
{
    [TestFixture]
    public class FiguresCalculateSquareTests
    {
        [Test]
        public void Test1()
        {
            var rectangleSquare = new Triangle(5, 5 * Math.Sqrt(2), 5).CalculateSquare();
            Assert.AreEqual(12.5, rectangleSquare);
        }

        [Test]
        public void Test2()
        {
            var circleSquare = new Circle(1.2).CalculateSquare();
            Assert.AreEqual(4.524, circleSquare, 0.001);
        }

        [Test]
        public void Test3()
        {
            Exception exception = null;
            try
            {
                var circleSquare = new Circle(-1.2).CalculateSquare();
            }
            catch (FigureException ex)
            {
                exception = ex;
            }

            Assert.True(exception is FigureException);
        }
        
        [Test]
        public void Test4()
        {
            Exception exception = null;
            try
            {
                var rectangleSquare = new Triangle(-1,3,15).CalculateSquare();
            }
            catch (FigureException ex)
            {
                exception = ex;
            }

            Assert.True(exception is FigureException);
        }
        
        
        [Test]
        public void Test5()
        {
            var isRectangular = new Triangle(12.2, 12.421, 17.410377393956743).IsRectangular();
            Assert.True(isRectangular);
        }
        
        
    }
}