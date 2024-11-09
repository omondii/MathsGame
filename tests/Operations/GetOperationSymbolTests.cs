using MathGameLogic;

namespace operationTests;

public class GetOperationSymbolTest
/*
GIVEN: A SUT configured for testing
WHEN: The `GetOperationSymbol` function is validly called
THEN: Returns the expected operation symbol based on the chosen operation.
*/
{
    [Theory]
    [InlineData(Operations.OperationsType.Addition, "+")]
    [InlineData(Operations.OperationsType.Subtraction, "-")]
    [InlineData(Operations.OperationsType.Multiplication, "*")]
    [InlineData(Operations.OperationsType.Division, "/")]

    public void ValidateSymbol(Operations.OperationsType operation, string expected)
    {
        // Act
        string actual = Operations.GetOperationSymbol(operation);

        // Assert
        Assert.Equal(expected, actual);
    }
}
