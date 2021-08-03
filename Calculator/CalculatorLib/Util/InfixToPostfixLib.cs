using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.Util
{
    public class InfixToPostfixLib
    {

        public string ConvertinfixToPostfix(string infixStr)
        {
            string postfixStr;

            string[] infixTokens = infixStr.Split(' ');
            Stack<string> stack = new Stack<string>();
            List<string> postfixList = new List<string>();
            double n;

            foreach (string token in infixTokens)
            {

                if (double.TryParse(token.ToString(), out n))
                {
                    postfixList.Add(token);
                }
                else
                if (token == "(")
                {
                    stack.Push(token);
                }
                else
                if (token == ")")
                {
                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        postfixList.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                if (isOperator(token) == true)
                {
                    while (stack.Count != 0 && Priority(stack.Peek()) >= Priority(token))
                    {
                        postfixList.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
            }

            while (stack.Count != 0)//if any operators remain in the stack, pop all & add to output list until stack is empty 
            {
                postfixList.Add(stack.Pop());
            }

            postfixStr = string.Join(" ", postfixList.ToArray());


            return postfixStr;
        }


        private int Priority(string c)
        {
            if (c == "^")
            {
                return 3;
            }
            else if (c == "*" || c == "/")
            {
                return 2;
            }
            else if (c == "+" || c == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private bool isOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double EvaluatePostfix(string postfixStr)
        {
            double result = 0;

            string[] tokens = postfixStr.Split(' ');

            Stack<double> s = new Stack<double>();
            double A, B, newValue = 0;

            foreach (string c in tokens)
            {


                if (!isOperator(c))
                {
                    s.Push(Convert.ToDouble(c));
                }
                else
                {
                    
                    A = s.Pop();
                    B = s.Pop();

                    switch (c)
                    {
                        case "^":
                            newValue = Math.Pow(B, A);
                            break;

                        case "*":
                            newValue = B * A;
                            break;

                        case "/":
                            newValue = B / A;
                            break;

                        case "+":
                            newValue = B + A;
                            break;

                        case "-":
                            newValue = B - A;
                            break;
                        default:
                            break;
                    }


                    s.Push(newValue);
                }

            }


            if (s.Count > 0)
                result = s.Pop();

            return result;

        }

    }



}
