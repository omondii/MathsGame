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
    // Incorrect User answers
    [InlineData(Operations.OperationsType.Addition, 34, 45, "2", 0)]
    [InlineData(Operations.OperationsType.Subtraction, 23, 35, "5", 0)]
    [InlineData(Operations.OperationsType.Multiplication, 10, 34, "3", 0)]
    [InlineData(Operations.OperationsType.Division, 46, 3, "100", 0)]

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
            Assert.Equal(returnValue, correctAnswer); // Return Vale check for a correct answer

            // Depending on the return value(1 0r 0) 
            if (returnValue == 1)
            {
                Assert.Equal(1, score); // Score updates by 1 for a correct answer
                // Assert.Single(history);
                Assert.Equal(num1, history[^1].FirstNumber);
                Assert.Equal(num2, history[^1].SecondNumber);
                Assert.Equal(int.Parse(userAnswer), history[^1].CorrectAnswer);
                Assert.Equal(score, history[^1].ScoreAfterRound);
                Assert.True(history[^1].IsCorrect);
            }
            else
            {
                Assert.Equal(-1, score); // For every incorrect answer after 3 attempts, score is -1
                Assert.Equal(num1, history[^2].FirstNumber);
                Assert.Equal(num2, history[^2].SecondNumber);
                Assert.Equal(int.Parse(userAnswer), history[^2].CorrectAnswer);
                Assert.Equal(score, history[^2].ScoreAfterRound);
                Assert.False(history[^2].IsCorrect);
            }
        }
    }
}