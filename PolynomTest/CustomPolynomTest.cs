using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynom;

namespace PolynomTest
{
    [TestClass]
    public class CustomPolynomTest
    {
        [TestMethod]
        public void Polynom_Create()
        {
            var polynom = new CustomPolynom(1, 0, 2, 0, 5);

            Assert.AreEqual(5, polynom.MaxPower);
        }

        [TestMethod]
        public void Polynom_EqualsOtherFirst()
        {
            var array = new double?[] {1, 0, 2, 4, 5};
            var first = new CustomPolynom(array);
            var second = new CustomPolynom(array);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Polynom_EqualsOtherSecond()
        {
            var array = new double?[] { 1, 0, 2, 4, 5 };
            var first = new CustomPolynom(array);
            var second = new CustomPolynom(array);

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Polynom_EqualsOtherNullReference()
        {
            var array = new double?[] { 1, 0, 2, 4, 5 };
            var first = new CustomPolynom(array);
            CustomPolynom second = null;

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        public void Polynom_NotEqualsOther()
        {
            var array = new double?[] { 1, 0, 2, 4, 5 };
            var first = new CustomPolynom(array);
            var second = new CustomPolynom(array);

            Assert.IsFalse(first != second);
        }

        [TestMethod]
        public void Polynom_Clone()
        {
            var array = new double?[] { 1, 0, 2, 4, 5 };
            var first = new CustomPolynom(array);
            var second = (CustomPolynom)first.Clone();

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Polynom_Addition()
        {
            var firstArray = new double?[] { 1, 0, 2, 4, 5 };
            var secondArray = new double?[] { 3, 6, 1, 0, 10, -2 };
            var resultArray = new double?[] { 4, 6, 3, 4, 15, -2 };
            var first = new CustomPolynom(firstArray);
            var second = new CustomPolynom(secondArray);
            var result = new CustomPolynom(resultArray);

            var summa = first + second;

            Assert.IsTrue(summa.Equals(result));
        }

        [TestMethod]
        public void Polynom_Subtraction()
        {
            var firstArray = new double?[] { 1, 0, 2, 4, 5 };
            var secondArray = new double?[] { 3, 6, 1, 0, 10, -2 };
            var resultArray = new double?[] { -2, -6, 1, 4, -5, 2 };
            var first = new CustomPolynom(firstArray);
            var second = new CustomPolynom(secondArray);
            var result = new CustomPolynom(resultArray);

            var difference = first - second;

            Assert.IsTrue(difference.Equals(result));
        }

        [TestMethod]
        public void Polynom_MultiplicationOnNumberFirst()
        {
            int number = 3;
            var firstArray = new double?[] { 1, 0, 2, 4, 5 };
            var resultArray = new double?[] { 3, 0, 6, 12, 15 };
            var first = new CustomPolynom(firstArray);
            var result = new CustomPolynom(resultArray);

            var product = first * number;

            Assert.IsTrue(product.Equals(result));
        }

        [TestMethod]
        public void Polynom_MultiplicationOnNumberSecond()
        {
            int number = 3;
            var firstArray = new double?[] { 1, 0, 2, 4, 5 };
            var resultArray = new double?[] { 3, 0, 6, 12, 15 };
            var first = new CustomPolynom(firstArray);
            var result = new CustomPolynom(resultArray);

            var product = number * first;

            Assert.IsTrue(product.Equals(result));
        }
    }
}
