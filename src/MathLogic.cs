namespace MathGameLogic;
public class MathLogic
{
    private List<GameHistory> history = new List<GameHistory>();
    public void StartGame()
    {
        Console.WriteLine("Welcome to the Math Game!");
        Console.WriteLine("Enter your name: ");
        string? name = Console.ReadLine();
        if (name != null)
        {
            NameValidator(name);
        }
        Console.WriteLine($"Hello {name}!");

        int score = 0;

        ShowMenu();

        bool gameOn = true;
        while (gameOn)
        {
            int operation = GetOperation();
            switch (operation)
            {
                case 1:
                    RepeatOperation(Operations.OperationsType.Addition, ref score);
                    break;
                case 2:
                    RepeatOperation(Operations.OperationsType.Subtraction, ref score);
                    break;
                case 3:
                    RepeatOperation(Operations.OperationsType.Multiplication, ref score);
                    break;
                case 4:
                    RepeatOperation(Operations.OperationsType.Division, ref score);
                    break;
                case 5:
                    DisplayGameHistory();
                    break;
                case 6:
                    gameOn = false;
                    Console.WriteLine("Goodbye!");
                    break;
            }
            Console.WriteLine($"Your Total Score is: {score}");
        }

    }

    private void DisplayGameHistory()
    {
        Console.WriteLine("Game history: ");
        foreach (var game in history)
        {
            Console.WriteLine($"Operations: {game.Operations}, Numbers: {game.FirstNumber} and {game.SecondNumber}," +
            $"Your Answer: {game.UserAnswer}, Correct Answer: {game.CorrectAnswer}" +
            $"Correct: {game.IsCorrect}, Score after Round: {game.ScoreAfterRound}");
        }
    } 

    public void ShowMenu()
    {
        Console.WriteLine("Choose an operation: ");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. View History");
        Console.WriteLine("6. Exit");
    }

    public static string NameValidator(string name)
    {
        if (string.IsNullOrEmpty(name) || !name.All(char.IsLetter) || name.Length < 2)
        {
            Console.WriteLine("Invalid name. Please enter a valid name: ");
            string? newName = Console.ReadLine();
            if (newName != null)
            {
                NameValidator(newName);
            }
        }
        return name;
    }

    public static int GetOperation()
    {
        if (int.TryParse(Console.ReadLine(), out int operation)) 
        {
            if (operation < 1 || operation > 6)
            {
                Console.WriteLine("Invalid operation. Please choose a valid operation: ");
                return GetOperation();
            }
            else
            {
                return operation;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number: ");
            return GetOperation();
        }
    }

    private void RepeatOperation(Operations.OperationsType operationType, ref int score)
    {
        
        for (int i = 0; i < 4; i++)
        {
            Operations.MathOperations(operationType, ref score, history);
        }
        ShowMenu();
    }

    public static (int, int) GenerateNumbers()
    {
        Random random = new Random();
        int firstNumber = random.Next(0, 101);
        int secondNumber = random.Next(0, 101);
        return (firstNumber, secondNumber);
    }
}