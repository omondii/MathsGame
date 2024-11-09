using MathGameLogic;

namespace operationTests;

public class MathOperationsTest
/*
GIVEN: A SUT configured for testing
WHEN: The `MathOperations` function is validly called
THEN: Returns the expected value and correctly update the score counter.
*/
{
    [Theory]
    // User Correct Answers
    [InlineData(Operations.OperationsType.Addition, 10, 10, "20", 1)]
    [InlineData(Operations.OperationsType.Subtraction, 20, 5, "15", 1)]
    [InlineData(Operations.OperationsType.Multiplication, 3, 10, "30", 1)]
    [InlineData(Operations.OperationsType.Division, 20, 2, "10", 1)]

    public void Test_userCorrectAnswer(Operations.OperationsType operation, int num1, int num2,
    string userAnswer, int returnValue)
    {
        // Arrange
        int score = 0;
        var history = new List<GameHistory>();

        // Mock UserInput via console
        string answer = userAnswer;
        using (var stringReader = new StringReader(answer))
        {
            Console.SetIn(stringReader);

            // Actual
            int correctAnswer = Operations.MathOperations(operation, ref score, history, num1, num2);

            // Assert
            Assert.Equal(returnValue, correctAnswer);
            Assert.Equal(1, score);
            Assert.Single(history);
        }
    }
}