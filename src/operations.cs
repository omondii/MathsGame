//we need an operation type
//operations symbols
// calculate the correct answer
namespace MathGameLogic;

public class Operations
{
    public static string GetOperationSymbol(OperationsType operation){
        return operation switch
        {
            OperationsType.Addition => "+",
            OperationsType.Subtraction => "-",
            OperationsType.Multiplication => "*",
            OperationsType.Division => "/",
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    public static int CalculateAnswer(int num1, int num2, OperationsType operations){
        return operations switch{
            OperationsType.Addition => num1 + num2,
            OperationsType.Subtraction => num1 - num2,
            OperationsType.Multiplication => num1 * num2,
            OperationsType.Division => num1 / num2,
            _ => 0
        };

    }

    public static int MathOperations(OperationsType operations, ref int score, List<GameHistory> history, int num1=0, int num2=0){
        if (num1 == 0 && num2 == 0)
        {
            (num1, num2) = MathLogic.GenerateNumbers();
        }
        string symbol = GetOperationSymbol(operations);
        int correctAnswer = CalculateAnswer(num1, num2, operations);

        for(int i = 0; i < 3; i++){
            Console.WriteLine($"What is {num1} {symbol} {num2}?");
            Console.WriteLine("Enter your answer: ");
            string? answer = Console.ReadLine();
            if(answer != null){
                if(int.TryParse(answer, out int userAnswer)){
                    if(userAnswer == correctAnswer){
                        Console.WriteLine("Correct!");
                        score++;
                        history.Add(new GameHistory(symbol, num1, num2, userAnswer, correctAnswer, score, true));
                        return 1;
                    }
                    else{
                        Console.WriteLine("Incorrect! Try again.");
                        score--;
                        history.Add(new GameHistory(symbol, num1, num2, userAnswer, correctAnswer, score, false));
                    }
                }
            }
        }
        Console.WriteLine($"The correct answer is {correctAnswer}");
        history.Add(new GameHistory(symbol, num1, num2, -1, correctAnswer, score, false));
        return 0;  
    }

     public enum OperationsType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
}



