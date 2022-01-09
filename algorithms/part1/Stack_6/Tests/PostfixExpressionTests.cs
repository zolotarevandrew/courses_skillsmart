using System;
using Xunit;

namespace Stack_6.Tests
{
    public class PostfixExpressionTests
    {
        [Fact]
        public void Result_EmptyString_ShouldThrowException()
        {
            //Act
            Assert.Throws<InvalidPostfixExpressionException>(() => new PostfixExpression("").Result);
        }
        
        [Fact]
        public void Result_InvalidString_ShouldThrowException()
        {
            //Act
            Assert.Throws<InvalidPostfixExpressionException>(() => new PostfixExpression("12+3*]").Result);
        }
        
        [Fact]
        public void Result_InvalidString2_ShouldThrowException()
        {
            //Act
            Assert.Throws<InvalidPostfixExpressionException>(() => new PostfixExpression("1+3*]").Result);
        }
        
        [Fact]
        public void Result_InvalidString3_ShouldThrowException()
        {
            //Act
            Assert.Throws<InvalidPostfixExpressionException>(() => new PostfixExpression("82+5*9=+").Result);
        }
        
        [Fact]
        public void Result_ValidString_ShouldReturn9()
        {
            //Act
            var expr = new PostfixExpression("1 2 + 3 *");
            
            //Arrange
            var res = expr.Result;
            
            //Assert
            Assert.Equal(9, res.Value);
        }
        
        [Fact]
        public void Result_ValidString2_ShouldReturn()
        {
            //Act
            var expr = new PostfixExpression("8 2 + 5 * 9 + =");
            
            //Arrange
            var res = expr.Result;
            
            //Assert
            Assert.Equal(59, res.Value);
        }
        
        [Fact]
        public void Result_ValidString3_ShouldReturn()
        {
            //Act
            var expr = new PostfixExpression("8 2 + 5 * 9 + 2 + =");
            
            //Arrange
            var res = expr.Result;
            
            //Assert
            Assert.Equal(61, res.Value);
        }
        
        [Fact]
        public void Result_ValidString4_ShouldReturn()
        {
            //Act
            var expr = new PostfixExpression("25 50 / 4 + 45 * =");
            
            //Arrange
            var res = expr.Result;
            
            //Assert
            Assert.Equal(202.5m, res.Value);
        }
        
        [Fact]
        public void Result_ValidString5_ShouldReturn()
        {
            //Act
            var expr = new PostfixExpression("500 2 * 4 + 45 / =");
            
            //Arrange
            var res = expr.Result;
            
            //Assert
            Assert.Equal(22.31m, res.Value);
        }
        
        [Fact]
        public void Result_InvalidExpression_ShouldThrowDivideByZeroException()
        {
            //Act
            var expr = new PostfixExpression("25 0 / 4 + 45 * =");
            
            //Arrange
            Assert.Throws<DivideByZeroException>( () => expr.Result);
        }
    }
}