using System;
using AlgorithmsDataStructures;

namespace Stack_6
{
    public class InvalidPostfixExpressionException : Exception
    {
        public InvalidPostfixExpressionException(string source) : base($"Invalid postfix expression: {source}")
        {
            
        }
    }
    public class PostfixExpression
    {
        private readonly string _expression;
        private Stack<Number> _numbersStack;
        
        public PostfixExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new InvalidPostfixExpressionException(expression);
            
            _expression = expression;
            _numbersStack = new Stack<Number>();
        }

        public Number Result
        {
            get
            {
                Number? currentNumber = null;
                for (int idx = 0; idx < _expression.Length; idx++)
                {
                    var chr = _expression[idx];
                    if (chr == ' ')
                    {
                        if (currentNumber != null) _numbersStack.Push(currentNumber);
                        currentNumber = null;
                        continue;
                    }
                    
                    var isNumber = Number.IsValid(chr);
                    var isExpression = Expression.IsValid(chr);

                    if (!isNumber && !isExpression)
                    {
                        throw new InvalidPostfixExpressionException(_expression);
                    }

                    if (isNumber)
                    {
                        if (currentNumber == null)
                        {
                            currentNumber = new Number(chr);
                        }
                        else
                        {
                            currentNumber.Append(chr);
                        }
                    }
                    
                    else if (isExpression)
                    {
                        currentNumber = null;
                        
                        var expression = new Expression(chr);
                        if (expression.IsResult)
                        {
                            if (_numbersStack.Size() != 1)
                                throw new InvalidPostfixExpressionException(_expression);
                            return _numbersStack.Pop();
                        }
                        if (_numbersStack.Size() != 2) 
                            throw new InvalidPostfixExpressionException(_expression);
                        
                        var last = _numbersStack.Pop();
                        var first = _numbersStack.Pop();
                        var result = expression.Calculate(first, last);
                        _numbersStack.Push(result);
                    }
                }
                return _numbersStack.Pop();
            }
        }

        class Expression
        {
            public static bool IsValid(char source)
            {
                return source == '*'
                       || source == '+'
                       || source == '/'
                       || source == '-'
                       || source == '=';
            }

            private char _source;
            
            public Expression(char source)
            {
                if (!IsValid(source))
                    throw new ArgumentOutOfRangeException(source.ToString());

                _source = source;
            }

            public bool IsResult => _source == '=';

            public Number Calculate(Number number1, Number number2)
            {
                switch (_source)
                {
                    case '+':
                        return number1 + number2;
                    case '-':
                        return number1 - number2;
                    case '/':
                        return number1 / number2;
                    case '*':
                        return number1 * number2;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public class Number
        {
            public static bool IsValid(char source)
            {
                return source == '0'
                       || source == '1'
                       || source == '2'
                       || source == '3'
                       || source == '4'
                       || source == '5'
                       || source == '6'
                       || source == '7'
                       || source == '8'
                       || source == '9';
            }

            private string _str;
            private decimal _value;
            public Number(char source)
            {
                if (!IsValid(source))
                    throw new ArgumentOutOfRangeException(source.ToString());

                Append(source);
            }

            private Number(decimal res)
            {
                _value = res;
            }

            public void Append(char item)
            {
                _str += item;
                _value = Convert.ToInt32(_str);
            }

            public decimal Value => _value;

            public static Number operator +(Number a, Number b)
            {
                var res = a._value + b._value;
                return new Number(res);
            }
            
            public static Number operator -(Number a, Number b)
            {
                var res = a._value - b._value;
                return new Number(res);
            }
            
            public static Number operator /(Number a, Number b)
            {
                var res = a._value / b._value;
                return new Number(decimal.Round(res, 2, MidpointRounding.AwayFromZero));
            }
            
            public static Number operator *(Number a, Number b)
            {
                var res = a._value * b._value;
                return new Number(res);
            }
        }
    }
}