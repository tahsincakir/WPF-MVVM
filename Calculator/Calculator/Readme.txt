

Notes 

1)  Please have a look at the attached   Calculator.zip 

2) .NET version 4.6.1 is used as framework

3) Calculation is done with infix2postfix algorithmic approach.



-- 

Feature’s requirements:

1) MMVM pattern is used.

2) input is read from expression.txt and output is written to value.txt.

3) At the moment app support +, -, /, *  and power with ^"( 3 ) ^ 4 + ( 11.5 - ( 3 * 2 ) ) / 2"
   It is possible to add sin, cos, etc. as well.
   
4) App supports parantheses.

5) All operands are real number with point delimiter.

6) At the moment, Operands and operators should  be separated with at least 1 spaces (1+ space is supported).
   Please have a look at test method in UTinfixToPostfixLib in the test project (CalculatorUnitTest) 
   to see the exact supported form.
   
   exp 1:  "3 ^ 4 + ( 11.5 - ( 3 * 2 ) ) / 2"
   exp 2:  "( 3 ) ^ 4 + ( 11.5 - ( 3 * 2 ) ) / 2"


7) The output value is rounded to 5 number after the delimeter.

8) The app  checks if given expression is correct and write reasonable message about what is the error and where it is located on screen 
   to related textblock in the way compatible with MVVM pattern.
