﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib;

namespace TriangleLibTest
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void SquareOf_3_4_5_returns6() //тест на то, что треугольник со сторонами 3,4,5 имеет площадь = 6
        {
            //arrange
            int side1 = 3, side2 = 4, side3 =5;
            int expected = 6;

            //act
            var triangle = new Triangle<int>(side1, side2, side3);
            float actual = triangle.SquareRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SquareOf_4_5_3_returns6() //тест на то, что треугольник со сторонами 4,5,3 имеет площадь = 6
        {
            //arrange
            int side1 = 3, side2 = 4, side3 = 5;
            int expected = 6;

            //act
            var triangle = new Triangle<int>(side2, side3, side1);
            float actual = triangle.SquareRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SquareOfDouble_1point5_2_2point5_returns1point5() //тест на то, что треугольник со сторонами 1.5,2,2.5 типа double имеет площадь = 1.5
        {
            //arrange
            double side1 = 1.5, side2 = 2, side3 = 2.5;
            double expected = 1.5;

            //act
            var triangle = new Triangle<double>(side1, side2, side3);
            float actual = triangle.SquareRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SquareOfFloat_1point5_2_2point5_returns1point5() //тест на то, что треугольник со сторонами 1.5,2,2.5 типа float имеет площадь = 1.5
        {
            //arrange
            float side1 = 1.5f, side2 = 2f, side3 = 2.5f;
            float expected = 1.5f;

            //act
            var triangle = new Triangle<double>(side1, side2, side3);
            float actual = triangle.SquareRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SquareOf_37_1_2_returns0() //тест на то, что треугольник со сторонами 37,1,2 типа double имеет площадь = 0
        {
            //arrange
            int side1 = 37, side2 = 1, side3 = 2;
            int expected = 0;

            //act
            var triangle = new Triangle<double>(side1, side2, side3);
            float actual = triangle.SquareRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRightTriangle_3_4_5_returnsTrue() //тест на то, что треугольник со сторонами 3,4,5 правильный
        {
            //arrange
            int side1 = 3, side2 = 4, side3 = 5;
            bool expected = true;

            //act
            var triangle = new Triangle<int>(side1, side2, side3);
            bool actual = triangle.IsRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRightTriangle_1_2_3_returnsFalse() //тест на то, что треугольник со сторонами 1,2,3 не правильный
        {
            //arrange
            int side1 = 1, side2 = 2, side3 = 3;
            bool expected = false;

            //act
            var triangle = new Triangle<int>(side1, side2, side3);
            bool actual = triangle.IsRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsRightTriangle_a_b_c_returnsFalse() //тест на то, что треугольник со сторонами типа char a,b,c не правильный
        {
            //arrange
            char side1='a', side2='b', side3='c';
            bool expected = false;

            //act
            var triangle = new Triangle<char>(side1, side2, side3);
            bool actual = triangle.IsRightTriangle();

            //assert
            Assert.AreEqual(expected, actual);
        }


    }
}
