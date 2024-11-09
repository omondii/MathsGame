using MathGameLogic;

namespace operationTests;

public class CalculateAnswerTest
/*
GIVEN: A SUT ready for testing
WHEN: The `CalculateAnswerTest` func receives valid operations 
THEN: Returns the correct answer 
*/
{
    [Theory]
    // Positive numbers
    [InlineData(10, 11, Operations.OperationsType.Addition, 21)]
    [InlineData(12, 6, Operations.OperationsType.Subtraction, 6)]
    [InlineData(23, 1, Operations.OperationsType.Multiplication, 23)]
    [InlineData(20, 2, Operations.OperationsType.Division, 10)]
    // Negative Numbers
    [InlineData(-21, -8, Operations.OperationsType.Addition, -29)]
    [InlineData(-13, -10, Operations.OperationsType.Subtraction, -3)]
    [InlineData(-5, -11, Operations.OperationsType.Multiplication, 55)]
    [InlineData(-24, -8, Operations.OperationsType.Division, 3)]
    // Negative & Positive Numbers
    [InlineData(-10, 8, Operations.OperationsType.Addition, -2)]
    [InlineData(85, -20, Operations.OperationsType.Subtraction, 105)]
    [InlineData(32, -9, Operations.OperationsType.Multiplication, -288)]
    [InlineData(-40, 10, Operations.OperationsType.Division, -4)]

    public void CalculateCorrectAnswer(int num1, int num2, Operations.OperationsType operation, int expected)
    {
        // Act
        int actual = Operations.CalculateAnswer(num1, num2, operation);

        // Assert
        Assert.Equal(expected, actual);
    }
}