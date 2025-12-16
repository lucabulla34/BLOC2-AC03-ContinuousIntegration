using Xunit;
using xUnitTestLibrary;

namespace xUnitTests
{
    public class IntegracioContinuaTests
    {
        [Theory]
        [InlineData(5, 8, 10, (5+8+10), "El resultat és positiu.")]
        [InlineData(20, 3, 0, (20+3), "El resultat és positiu.")]
        [InlineData(10, -2, 3, (10), "El resultat és positiu.")]
        [InlineData(0, -10, 25, (0), "El resultat és zero.")]
        [InlineData(-10, 200, 3, (0), "El resultat és zero.")]

        public void TC1_Add_Numbers(int firstNum, int secondNum, int thirdNum, int expectedResultInt, string expectedResultString)
        {
            //Arrange
            int result;
            string actualString;

            //Act
            result = TestsLibrary.SumNumbers(firstNum, secondNum, thirdNum);
            actualString = TestsLibrary.DescriptionResult(result);

            //Assert
            Assert.Equal(expectedResultInt, result);
            Assert.Equal(expectedResultString, actualString);
        }
    }
}
