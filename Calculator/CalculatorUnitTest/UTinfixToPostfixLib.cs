using System;
using CalculatorLib.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTest
{
    [TestClass]
    public class UTinfixToPostfixLib
    {
        
        [TestMethod]
        public void infix2PostfixTest01()
        {
            //3A
            //Arrange/assign
            string infixStr = "3 ^ 4 + ( 11.5 - ( 3 * 2 ) ) / 2";
            InfixToPostfixLib infixToPostfixLib = new InfixToPostfixLib();

            //Act
            string postfixStr = infixToPostfixLib.ConvertinfixToPostfix(infixStr);

            //Assert
            Assert.AreEqual("3 4 ^ 11.5 3 2 * - 2 / +", postfixStr);

        }

        [TestMethod]
        public void infix2PostfixTest02()
        {
            //Arrange
            string infixStr = "( 3 ) ^ 4 + ( 11.5 - ( 3 * 2 ) ) / 2";
            InfixToPostfixLib infixToPostfixLib = new InfixToPostfixLib();

            //Act
            string postfixStr = infixToPostfixLib.ConvertinfixToPostfix(infixStr);

            //Assert
            Assert.AreEqual("3 4 ^ 11.5 3 2 * - 2 / +", postfixStr);
        }


        [TestMethod]
        public void infix2PostfixTest03()
        {
            //Arrange
            string infixStr = "( 0 - 3 ) ^ 4 + ( 11.5 - ( 3 * 2 ) ) / 2";
            InfixToPostfixLib infixToPostfixLib = new InfixToPostfixLib();

            //Act
            string postfixStr = infixToPostfixLib.ConvertinfixToPostfix(infixStr);

            //Assert
            Assert.AreEqual("0 3 - 4 ^ 11.5 3 2 * - 2 / +", postfixStr);

        }

        [TestMethod]
        public void PostfixEvalTest03()
        {

            //Arrange
            string infixStr = "( 2 - 3 ) * 3 + ( 4 - ( 1 * 2 ) ) / 2";
            InfixToPostfixLib infixToPostfixLib = new InfixToPostfixLib();


            //Act
            string postfixStr = infixToPostfixLib.ConvertinfixToPostfix(infixStr);
            double postfixResult = infixToPostfixLib.EvaluatePostfix(postfixStr);

            //Assert
            Assert.AreEqual(-2, postfixResult);

        }

    }
}
