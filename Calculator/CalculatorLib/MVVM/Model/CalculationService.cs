using CalculatorLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.MVVM.Model
{
    public class CalculationService
    {

        CalculatorLib.Util.InfixToPostfixLib infixToPostfixLib;


        public CalculationService()
        {
            infixToPostfixLib = new CalculatorLib.Util.InfixToPostfixLib();
        }

        public bool Calculate(Calculation calculation) {

            bool isCalculated = false;
            calculation.Message = "";
            try
            {
                string postfixExpression = infixToPostfixLib.ConvertinfixToPostfix(calculation.ExpressionTxt); // expressionTxt is in infix form


                double outputValue = infixToPostfixLib.EvaluatePostfix(postfixExpression);
                calculation.OutputValue = Math.Round(outputValue, 5);
                isCalculated = true;
                calculation.Message = "Successful";
            }
            catch (Exception ex)
            {
                calculation.Message = ex.Message;
                throw ex;
            }


            return isCalculated;
        }

    }
}
