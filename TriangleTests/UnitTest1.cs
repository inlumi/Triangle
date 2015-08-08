using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpcTriangle;

namespace TriangleTests
{
    [TestClass]
    public class TriangleUnitTest
    {
        /// <summary>
        /// Пробует создать несуществующий треугольник (одна из сторон больше суммы двух других)
        /// </summary>
        [TestMethod]
        public void CreateUnexistingTriangle()
        {
            // Arrange
            float Side1 = 1.0F;
            float Side2 = 1.0F;
            float Side3 = 2.0F;
            bool expected = false;
            bool actual = true;

            // Act
            try
            {
                Triangle UnexistTriangle = TriangleFactory.CreateTriangle(Side1, Side2, Side3);
            }
            catch(System.ArgumentException)
            {
                actual = false;
            }

            //  Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверяет правильность подсчёта площади обычного треугольника.
        /// </summary>
        [TestMethod]
        public void TryCountSimpleSpace()
        {
            // Arrange
            float Side1 = 4.0F;
            float Side2 = 5.0F;
            float Side3 = 6.5F;
            double _expected = 9.99511599482467;

            //Act
            Triangle SimpleTriangle = TriangleFactory.CreateTriangle(Side1, Side2, Side3);
            double actual = SimpleTriangle.CountSpace();

            //Assert
            Assert.AreEqual((Math.Abs(_expected - actual) < 0.1), true);
        }
        /// <summary>
        /// Пробует создать треугольник с существующими сторонами, не являющийся правильным.
        /// Проверяет, является ли созданный треугольник инстансом класса простого, не правильного треугольника.
        /// Так же создаёт правильный треугольник и проверяет, является ли он объектом класса правильного треугольника.
        /// </summary>
        [TestMethod]
        public void CreateRightTriangle()
        {
            // Arrange
            float Side1 = 4.1F;
            float Side2 = 5.0F;
            float Side3 = 6.5F;
            float Cath1 = 3.0F;
            float Cath2 = 4.0F;
            float Hypo = 5.0F;

            // Act
            Triangle rightTriangle = TriangleFactory.CreateTriangle(Cath1, Cath2, Hypo);
            Triangle notRightTriangle = TriangleFactory.CreateTriangle(Side1, Side2, Side3);

            //  Assert
            Assert.AreEqual(rightTriangle is RightTriangle, true);
            Assert.AreEqual(notRightTriangle is RightTriangle, false);
        }
        /// <summary>
        /// Проверяет правильность подсчёта площади правильного треугольника.
        /// </summary>
        [TestMethod]
        public void TryCountRightSpace()
        {
            // Arrange
            float Side1 = 3.0F;
            float Side2 = 4.0F;
            float Side3 = 5.0F;
            double _expected = 6.0;

            //Act
            Triangle SimpleTriangle = TriangleFactory.CreateTriangle(Side1, Side2, Side3);
            double actual = SimpleTriangle.CountSpace();

            //Assert
            Assert.AreEqual((Math.Abs(_expected - actual) < 0.1), true);
        }
    }
}
